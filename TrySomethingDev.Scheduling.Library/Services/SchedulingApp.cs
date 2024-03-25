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
        private Jobs _jobs;


        public SchedulingApp()
        {
            _importManager = new ImportManager(this);
            _resources = new Resources(this);
            _jobs = new Jobs(this);
            _sequencer = new Sequencer(this);
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

        public Jobs GetJobs()
        {
            return _jobs;
        }
    }

}
