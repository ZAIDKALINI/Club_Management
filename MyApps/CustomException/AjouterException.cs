using System;

namespace CustomException
{
    public class AjouterException: Exception
    {
        public AjouterException() : base(String.Format("Echeq d'ajout, réessayer une autre fois"))
        {

        }
     
    }
    public class ModifierException : Exception
    {
        public ModifierException() : base(String.Format("Echeq de modifier, réessayer une autre fois "))
        {

        }

    }
    public class SupprimerException : Exception
    {
        public SupprimerException() : base(String.Format("Echeq d'suppression, réessayer une autre fois"))
        {

        }

    }
}
