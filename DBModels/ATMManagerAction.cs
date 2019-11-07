using System;

namespace DBModels
{
    public class ATMManagerAction
    {
        #region Fields

        private DateTime _actionDate;

        #endregion

        #region Constructors

        // TODO add another constructor
        public ATMManagerAction()
        {
            _actionDate = DateTime.Now;
        }

        #endregion

        #region Properties

        public DateTime ActionDate
        {
            get { return _actionDate;}
            set { _actionDate = value; }
        }

        #endregion
    }
}