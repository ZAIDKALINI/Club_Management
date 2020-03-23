using DataAccessLayer;
using Entities.StatisticRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Statistics_ExpenseRepo
{
    public class Reporting
    {
        UnitOfWork uow = new UnitOfWork();
        List<Reports> reports;
        public Reporting()
        {
            reports = new List<Reports>();
        }
        /// <summary>
        /// Get report for new customer
        /// </summary>
        /// <returns></returns>
        public IList<Reports> getDailyReport()
        {
           var lstC= uow.ExpenseRepo.GetElements(r => r.ExpenseDate == DateTime.Now);
           var lstD= uow.PayementsRepo.GetElements(r => r.Payement_date == DateTime.Now);
            //Insert Creditor
            foreach (var item in lstC)
            {
                reports.Add(new Reports()
                {
                    Date = item.ExpenseDate,
                    Description = item.Description,
                    Creditor = item.Price,
                    Debit=0
                }) ;
            }

            //Insert Debit
            foreach (var item in lstD)
            {
                reports.Add(new Reports()
                {
                    Date = item.Payement_date,
                    Description = "Paiement client",
                    Creditor = 0,
                    Debit = item.Price
                });
            }
            return reports;
           
        }

        public IList<Reports> getMonthlyReport(DateTime from,DateTime to)
        {
            var lstC = uow.ExpenseRepo.GetElements(r => r.ExpenseDate >= from && r.ExpenseDate<=to);
            var lstD = uow.PayementsRepo.GetElements(r => r.Payement_date >= from && r.Payement_date <= to);
            foreach (var item in lstC)
            {
                reports.Add(new Reports()
                {
                    Date = item.ExpenseDate,
                    Description = item.Description,
                    Creditor = item.Price,
                    Debit = 0
                });
            }

            //Insert Debit
            foreach (var item in lstD)
            {
                reports.Add(new Reports()
                {
                    Date = item.Payement_date,
                    Description = "Paiement client",
                    Creditor = 0,
                    Debit = item.Price
                });
            }
            return reports;
        }
    }
}
