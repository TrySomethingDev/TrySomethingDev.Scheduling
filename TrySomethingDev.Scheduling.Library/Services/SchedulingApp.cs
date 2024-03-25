using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrySomethingDev.Scheduling.Library.Services
{
    public class SchedulingApp
    {
        private Sequencer _sequencer;
        private Resources _resources;
        private ImportManager _importManager;

        public object Resources { get; set; }

        public SchedulingApp()
        {
            _importManager = new ImportManager();
            _resources = new Resources();
            _sequencer = new Sequencer();
        }

        public ImportManager GetImportManager()
        {
            return _importManager;
        }

        public Sequencer GetSequencer()
        {
            return _sequencer;
        }

        public Resources GetResources()
        {
            return _resources;
        }
    }

}
