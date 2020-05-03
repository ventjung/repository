using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventjung.Repository.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // init
            SampleContext ctx = new SampleContext();
            UnitOfWork unitOfWork = new UnitOfWork(ctx);

            // unitOfWork.StartTransaction(); // simply add start transaction to make below operations transactional

            var sampleTableRepo = unitOfWork.Repository<SampleTable>();

            // insert
            sampleTableRepo.Create(new SampleTable()
            {
                SampleTableString = "Sample Data"
            });
            sampleTableRepo.SaveChanges(); // don't forget to save changes
            
            // get list
            var list = sampleTableRepo.GetList();

            // unitOfWork.Commit(); // end with a commit if you start transaction
        }
    }
}
