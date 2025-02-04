namespace OnlineOrdering;

public class Customer
{
       private string _fullName;
       private Address _address;

       public Customer(string fullName, Address address)
       {
              _fullName = fullName;
              _address = address;
       }

       public string GetFullName()
       {
              return _fullName;
       }
       
       public string GetAddress()
       {
              return _address.GetAddress();
       }

       public bool InUsa()
       {
              return _address.UsaAddress();
       }
}