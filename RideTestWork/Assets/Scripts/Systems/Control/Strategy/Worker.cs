using Assets.Scripts.Systems.Control.Strategy.Interfaces;
using Assets.Scripts.Utility;

namespace Assets.Scripts.Systems.Control.Strategy
{
    public class Worker
    {
        #region public Setters
        public IBreakDownJob BreakDownJob { set => _breakDownJob = value; }
        public IBreakUpJob BreakUpJob { set => _breakUpJob = value; }
        public IGasDownJob GasDownJob { set => _gasDownJob = value; }
        public IGasUpJob GasUpJob { set => _gasUpJob = value; }
        #endregion

        #region Jobs
        private IBreakDownJob _breakDownJob;
        private IBreakUpJob _breakUpJob;
        private IGasDownJob _gasDownJob;
        private IGasUpJob _gasUpJob;
        #endregion

        #region Constructors
        private Worker() { }
        private Worker(IBreakDownJob breakDownJob = null, IBreakUpJob breakUpJob = null, IGasDownJob gasDownJob = null, IGasUpJob gasUpJob = null)
        {
            _breakDownJob = breakDownJob;
            _breakUpJob = breakUpJob;
            _gasDownJob = gasDownJob;
            _gasUpJob = gasUpJob;
        }
        #endregion

        #region JobCalls
        /// <returns>Is need to update</returns>
        public bool? BreakDown(CarObject car) => _breakDownJob?.BreakDown(car);
        /// <returns>Is need to update</returns>
        public void BreakUp(CarObject car) => _breakUpJob?.BreakUp(car);
        /// <returns>Is need to update</returns>
        public bool? GasDown(CarObject car) => _gasDownJob?.GasDown(car);
        /// <returns>Is need to update</returns>
        public void GasUp(CarObject car) => _gasUpJob?.GasUp(car);
        #endregion

        #region Singleton
        private static Worker _instance;

        public static Worker Instance 
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Worker();
                }

                return _instance;
            }
        }
        #endregion

        public void ClearJobs()
        {
            _breakDownJob = null;
            _breakUpJob = null;
            _gasDownJob = null;
            _gasUpJob = null;
        }
    }
}
