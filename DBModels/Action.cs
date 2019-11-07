using System;

namespace DBModels
{
    public class Action
    {
        #region Fields

        private int _actionId;
        private ActionType _actionType;
        private DateTime _actionDate;

        #endregion


        #region Constructors

        public Action()
        {
            
        }

        public Action(int actionId, ActionType actionType) : this()
        {
            _actionId = actionId;
            _actionType = actionType;
            _actionDate = DateTime.Now;
        }

        #endregion

        #region Properties

        public int ActionId
        {
            get { return _actionId;}
            set { _actionId = value; }
        }

        public ActionType ActionType
        {
            get { return _actionType; }
            set { _actionType = value; }
        }

        public DateTime ActionDate
        {
            get { return _actionDate; }
            set { _actionDate = value; }
        }

        #endregion
        
    }
}