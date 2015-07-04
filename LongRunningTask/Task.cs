namespace LongRunningTask
{
    using System;
    using System.Threading;

    /// <summary>
    /// Class to wrap and handle any long running task
    /// </summary>
    public class LengthyTask
    {
        // property to indicate if task has run at least once.
        private bool _firstRunComplete = false;
        public bool FirstRunComplete
        {
            get { return _firstRunComplete; }
        }

        // property to indicate iftask is running.
        private bool _running = false;
        public bool Running
        {
            get { return _running; }
        }

        //property to indicate whether the last task succeeded.

        public bool _lastTaskSuccess = true;
        public bool LastTaskSuccess
        {
            get
            {
                if( _lastFinishTime == DateTime.MinValue )
                    throw new InvalidOperationException( "The task has never completed." );
                return _lastTaskSuccess;
            }
        }

        //store any exception generated during the task.
        private Exception _exceptionOccured = null;
        public Exception ExceptionOccured
        {
            get { return _exceptionOccured; }
        }

        private DateTime _lastStartTime = DateTime.MinValue;
        public DateTime LastStartTime
        {
            get
            {
                if( _lastStartTime == DateTime.MinValue )
                {
                    throw new InvalidOperationException( "The task has never started." );
                }

                return _lastStartTime;
            }
        }

        private DateTime _lastFinishTime = DateTime.MinValue;
        public DateTime LastFinishTime
        {
            get
            {
                if( _lastFinishTime == DateTime.MinValue )
                {
                    throw new InvalidOperationException( "The task has never completed." );
                }

                return _lastFinishTime;
            }
        }

        // Start the task
        public void RunTask()
        {
            // Only one thread is allowed to enter here.
            lock( this )
            {
                if( !_running )
                {
                    _running = true;
                    _lastStartTime = DateTime.Now;
                    Thread t = new Thread( new ThreadStart( DoWork ) );
                    t.Start();
                }
                else
                {
                    throw new InvalidOperationException( "The task is already running!" );
                }
            }
        }

        public void DoWork()
        {
            try
            {
                // Next line is a placeholder for your "job" - a DTS package or other long-running task
                // Replace the following line with your code.
                Thread.Sleep( 18000 );

                // Set Success property.
                _lastTaskSuccess = true;
            }
            catch( Exception e )
            {
                // Task Failed.
                _lastTaskSuccess = false;
                _exceptionOccured = e;
            }
            finally
            {
                _running = false;
                _lastFinishTime = DateTime.Now;
                if( !_firstRunComplete ) _firstRunComplete = true;
            }
        }
    }
}