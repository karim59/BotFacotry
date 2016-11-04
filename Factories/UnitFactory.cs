using BotFactory.Common.Tools;
using BotFactory.Common.Interface;
using BotFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common;
using BotFactory.Reporting;
using System.Threading;

namespace BotFactory.Factories
{
    public class UnitFactory : IUnitFactory
    {
        public FactoryProgress FactoryProgress { get; set; }
        public int QueueCapacity { get; set; }
        public int StorageCapacity { get; set; }
        public TimeSpan QueueTime { get; set; }
        public int QueueFreeSlots {
            get
            {
                return QueueCapacity - _storage.Count;
            }
            set { }
        }
        public int StorageFreeSlots {
            get
            {
                return StorageCapacity - _storage.Count;
            }
            set { } }

        private static object Obj = new Object();
        private List<IFactoryQueueElement> _queue;
        public List<IFactoryQueueElement> Queue
        {
            get
            {
                return _queue.ToList();
            }
        }

        private List<ITestingUnit> _storage;

        public List<ITestingUnit> Storage
        {
            get
            {
                return _storage.ToList();
            }
        }

       


        public UnitFactory(int queueCapacity, int storageCapacity)
        {
            _queue = new List<IFactoryQueueElement>();
            _storage = new List<ITestingUnit>();
            QueueCapacity = queueCapacity;
            StorageCapacity = storageCapacity;
            QueueFreeSlots = queueCapacity;
            StorageFreeSlots = storageCapacity;
        }

        public async Task<bool> AddWorkableUnitToQueue(Type model, string name, Coordinates parkingPos, Coordinates workingPos)
        {
            FactoryQueueElement queuedElement = null;
            if (QueueFreeSlots > 0)
            {
                queuedElement = new FactoryQueueElement()
                {
                    Name = name,
                    Model = model,
                    ParkingPos = parkingPos,
                    WorkingPos = workingPos
                };
                _queue.Add(queuedElement);
                OnUnitStatusChanged(new StatusChangedEventArgs() { NewStatus = String.Format("Element ajouté en queue => {0}", _queue.First().Name) });
                QueueFreeSlots--;
            }
            var result = await Task.Run(() =>
              {
                  
                      return AddWorkableUnitToStorage(queuedElement);
                  
              });

            if (_queue.Count>0)
            { 
                _queue.Remove(queuedElement);
            
            }

            return result;
        }

        private void OnUnitStatusChanged(StatusChangedEventArgs statusChangedEventArgs)
        {
            if (FactoryProgress != null)
            {
                FactoryProgress(this, statusChangedEventArgs);
            }
        }

        private bool AddWorkableUnitToStorage(FactoryQueueElement QElement)
        {
            lock (Obj)
            {
                if (StorageFreeSlots > 0 && QElement != null)
                {
                    ITestingUnit element = InstanceElement(QElement);
                    _storage.Add(element);
                    OnUnitStatusChanged(new StatusChangedEventArgs() { NewStatus = String.Format("Element supprimé de Queue => {0}", _queue.First().Name) });
                    OnUnitStatusChanged(new StatusChangedEventArgs() { NewStatus = String.Format("Element stocké => {0}", _storage.First().Name) });
                    return true;
                }
                return false;

            }
        }

        private ITestingUnit InstanceElement(FactoryQueueElement queuedElement)
        {
            ITestingUnit element = (ITestingUnit)Activator.CreateInstance(queuedElement.Model);
            Thread.Sleep(TimeSpan.FromSeconds(element.BuildTime));
            element.ParkingPos = queuedElement.ParkingPos;
            element.WorkingPos = queuedElement.WorkingPos;
            element.CurrentPos = queuedElement.ParkingPos;
            element.Name = queuedElement.Name;
            element.Model = queuedElement.Model.Name;
            return element;

        }
    }
}
