using System;
namespace SharedProject.Classes
{
    public static class ExpireCheck
    {

        public static bool Check(string date, string start)
        {
            DateTime _date = DateTime.Now;
            DateTime _start = DateTime.Now;
            try
            {

                _date = Convert.ToDateTime(date);
                _start = Convert.ToDateTime(start);

            }
            catch (Exception)
            {
                _date = DateTime.Now.AddDays(1);
                _start = DateTime.Now.AddHours(1);
            }


            if ((_date.Date < DateTime.Now.Date))
            {
                return true;


            }
            else if ((_date.Date == DateTime.Now.Date) && _start.TimeOfDay <= DateTime.Now.TimeOfDay)
            {
                return true;
            }


            return false;
        }
    }
}
