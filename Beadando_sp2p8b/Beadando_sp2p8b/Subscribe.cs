using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beadando_sp2p8b
{
    public class Subscribe
    {
        public string Subscription(string email, bool elfogad)
        {
            if (!ValidateEmail(email))
                throw new ValidationException(
                    "A megadott e-mail cím nem megfelelő!");

            if (!ValidateFeliratkozas(elfogad))
                throw new ValidationException(
                    "Kérem fogadja el a feliratkozásra vonatkozó szabályokat.");

            MessageBox.Show("Köszönjük!");
            return email;

        }

        public bool ValidateEmail(string email)
        {
            return Regex.IsMatch(
                email,
                @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        }

        public bool ValidateFeliratkozas(bool elfogad)
        {
            if (elfogad)
            {
               return true;
            }
            else
            {
                return false;
            }
                
        }
    }
}
