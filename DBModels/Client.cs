namespace DBModels
{
    public class Client
    {
        #region Fields

        private string _itn;
        private string _firstName;
        private string _lastName;

        #endregion

        #region Constructors

        public Client()
        {
            
        }

        public Client(string itm, string firstName, string lastName) : this()
        {
            _itn = itm;
            _firstName = firstName;
            _lastName = lastName;
        }

        #endregion

        #region Properties

        public string ITN
        {
            get { return _itn;}
            set { _itn = value; }
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

        #endregion

        public override string ToString()
        {
            return FirstName + " " + LastName + "; ITN: " + ITN;
        }
    }
}