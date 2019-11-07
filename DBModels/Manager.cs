namespace DBModels
{
    public class Manager
    {
        #region Fields

        private string _managerId;
        private string _firstName;
        private string _lastName;
        private string _password;

        #endregion

        #region Constructors

        public Manager()
        {

        }

        public Manager(string managerId, string firstName, string lastName, string password) : this()
        {
            _managerId = managerId;
            _firstName = firstName;
            _lastName = lastName;
            _password = password;
        }

        #endregion

        #region Properties

        public string ManagerId
        {
            get { return _managerId; }
            set { _managerId = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        #endregion

        public override string ToString()
        {
            return "Manager " + FirstName + " " + LastName + "; ID: " + ManagerId;
        }
    }
}