using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

using Smps.Core.BusinessObjects.Holder;
using Smps.Core.Interfaces.Holder.Repositories;
using System.Net.Mail;


namespace Smps.Infrastructure.Data.Repositories
{
    public class HolderServiceRepository : IHolderServiceRepository, IDisposable
    {
        private readonly MYEntity objectContext = new MYEntity();

        public List<HolderPerson> GetHoldersTabledetail(int? id)
        {
            List<HolderDetail> holderDetails= new List<HolderDetail>();
            List<HolderPerson> holderPerson = new List<HolderPerson>();
            holderDetails = objectContext.HolderDetails.Where(e => e.EmpNo == id).ToList();

            foreach (HolderDetail hd in holderDetails)
            {

                holderPerson.Add(MapHolder(hd)); 



            }

       return holderPerson;

        }

        public HolderPerson MapHolder(HolderDetail hd)
        {
            HolderPerson hldperson= new HolderPerson()
            {
               EmpNo = hd.EmpNo,
               ParkingSlotNumber = hd.ParkingSlotNumber.ToString(),
               Startdate = Convert.ToString(hd.CreatedDate),
               Enddate = Convert.ToString(hd.SlotReleasedDate),
               OperationType = hd.OperationType
               



            };



            return hldperson;
        }




        public List<HolderPerson> Multipleslotreleases(HolderPerson hld, DateTime startDate, DateTime EndDate)
        {
            List<HolderDetail> l= new List<HolderDetail>();
            List<SeekerDetail> s = new List<SeekerDetail>();
                var sdateAndTime = startDate;
                var sdate = sdateAndTime.Date;

                var edateAndTime = EndDate;
                var edate = edateAndTime.Date;
            int seekerid = Convert.ToInt32(hld.SeekerId);
                l = objectContext.HolderDetails.Where(h => h.EmpNo == hld.EmpNo).ToList();
                l = l.FindAll(h => h.CreatedDate >= startDate).ToList();
                l=l.FindAll(h => h.CreatedDate <= EndDate).ToList();

            s = objectContext.SeekerDetails.Where(e=>e.EmpNo== seekerid).ToList();
            s = s.FindAll(h => h.CreatedDate >= startDate).ToList();
            s = s.FindAll(h => h.CreatedDate <= EndDate).ToList();
            List<HolderPerson> lhp = new List<HolderPerson>();
            List<SeekerDetail> lsp = new List<SeekerDetail>();


                User usr = objectContext.Users.Single(u => u.EmpNo == hld.EmpNo);

                if (!l.Any())

               {
                    List<DateTime> allDates = new List<DateTime>();
                //OfferToSeeker(hld, startDate, EndDate, lsp, lhp, usr, s);


                #region one
                for (DateTime i = startDate; i <= EndDate; i = i.AddDays(1))
                {

                    ///code for multiple
                    if (hld.SeekerId != null)
                    {

                        


                        if (!(s.Exists(p => p.CreatedDate == i)))
                        {
                            objectContext.Database.ExecuteSqlCommand(
                             "sp_holderdatainsertion @EmpNo={0},@ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3},@AllocationType={4},@OperationType={5}",
                           hld.EmpNo, hld.ParkingSlotNumber, i, i, 1, 0);



                            objectContext.Database.ExecuteSqlCommand(
                                        "sp_seekerdetails @EmpNo={0}, @ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3}, @AllocationType={4},@OperationType={5}",
                                        seekerid, hld.ParkingSlotNumber, i, i, 1, 0);

                            lsp.Add(new SeekerDetail()
                            {
                                EmpNo = seekerid,
                                CreatedDate = i,
                                ParkingSlotNumber = hld.ParkingSlotNumber




                            });





                        }else { 

                        objectContext.Database.ExecuteSqlCommand(
                             "sp_holderdatainsertion @EmpNo={0},@ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3},@AllocationType={4},@OperationType={5}",
                           hld.EmpNo, hld.ParkingSlotNumber, i, i, 0, 1);

                        }

                        lhp.Add(new HolderPerson
                        {
                            EmpNo = hld.EmpNo,
                            Startdate = i.ToString(),
                            FirstName = usr.FirstName,
                            LastName = usr.LastName,
                            ParkingSlotNumber = hld.ParkingSlotNumber,
                            OperationType = 1
                        });


                    }
                    else
                    {


                        objectContext.Database.ExecuteSqlCommand(
                             "sp_holderdatainsertion @EmpNo={0},@ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3},@AllocationType={4},@OperationType={5}",
                           hld.EmpNo, hld.ParkingSlotNumber, i, i, 0, 1);

                        lhp.Add(new HolderPerson
                        {
                            EmpNo = hld.EmpNo,
                            Startdate = i.ToString(),
                            FirstName = usr.FirstName,
                            LastName = usr.LastName,
                            ParkingSlotNumber = hld.ParkingSlotNumber,
                            OperationType = 1
                        });
                    }

                }
                #endregion one
                if (lsp.Count>0)
                {

                    sendmail(lsp);
                }




                sendmail(lhp);
                return lhp.ToList();

              }
            if (l.Any())
            {

               // OfferToSeeker(hld, startDate, EndDate, lsp, lhp, usr, s);
                #region two
                for (DateTime i = startDate; i <= EndDate; i = i.AddDays(1))
                {

                    l = l.FindAll(h => h.CreatedDate >= startDate).ToList();
                    l = l.FindAll(h => h.CreatedDate <= EndDate).ToList();




                    if (!(l.Exists(p => p.CreatedDate == i)))
                    {


                        if (hld.SeekerId != null)
                        {

                            



                            if (!(s.Exists(p => p.CreatedDate == i)))
                            {

                                objectContext.Database.ExecuteSqlCommand(
                                 "sp_holderdatainsertion @EmpNo={0},@ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3},@AllocationType={4},@OperationType={5}",
                               hld.EmpNo, hld.ParkingSlotNumber, i, i, 1, 0);



                                objectContext.Database.ExecuteSqlCommand(
                                            "sp_seekerdetails @EmpNo={0}, @ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3}, @AllocationType={4},@OperationType={5}",
                                            seekerid, hld.ParkingSlotNumber, i, i, 1, 0);

                                lsp.Add(new SeekerDetail()
                                {
                                    EmpNo = seekerid,
                                    CreatedDate = i,
                                    ParkingSlotNumber = hld.ParkingSlotNumber




                                });





                            }else
                            {
                                objectContext.Database.ExecuteSqlCommand(
                               "sp_holderdatainsertion @EmpNo={0},@ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3},@AllocationType={4},@OperationType={5}",
                             hld.EmpNo, hld.ParkingSlotNumber, i, i, 0, 1);



                            }
                            



                            


                        }else
                        {
                            objectContext.Database.ExecuteSqlCommand(
                                "sp_holderdatainsertion @EmpNo={0},@ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3},@AllocationType={4},@OperationType={5}",
                              hld.EmpNo, hld.ParkingSlotNumber, i, i, 0, 1);


                        }







                        lhp.Add(new HolderPerson
                        {
                            EmpNo = hld.EmpNo,
                            Startdate = i.ToString(),
                            FirstName = usr.FirstName,
                            LastName = usr.LastName,
                            ParkingSlotNumber = hld.ParkingSlotNumber,
                            OperationType = 1
                        });
                    }

                    if (lsp.Count > 0)
                    {

                        sendmail(lsp);
                    }




                    



                }

                #endregion two

            }

                foreach (HolderDetail h in l)
                {
                    lhp.Add(new HolderPerson
                    {
                        EmpNo = hld.EmpNo,
                        Startdate = h.CreatedDate.ToString(),
                        FirstName = usr.FirstName,
                        LastName = usr.LastName,
                        ParkingSlotNumber = hld.ParkingSlotNumber,
                        OperationType = -1
                        
                    });
                }

            sendmail(lhp);
            return lhp.ToList();
                
            
            
        }
        #region
        //public void OfferToSeeker(HolderPerson hld, DateTime startDate, DateTime EndDate, List<SeekerDetail> lsp, List<HolderPerson> lhp, User usr, List<SeekerDetail> s)
        //{
        //    int seekerid = Convert.ToInt32(hld.SeekerId);
            
        //    for (DateTime i = startDate; i <= EndDate; i = i.AddDays(1))
        //    {

        //        ///code for multiple
        //        if (hld.SeekerId != null)
        //        {

        //            objectContext.Database.ExecuteSqlCommand(
        //                 "sp_holderdatainsertion @EmpNo={0},@ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3},@AllocationType={4},@OperationType={5}",
        //               hld.EmpNo, hld.ParkingSlotNumber, i, i, 1, 0);



        //            if (!(s.Exists(p => p.CreatedDate == i)))
        //            {

        //                objectContext.Database.ExecuteSqlCommand(
        //                            "sp_seekerdetails @EmpNo={0}, @ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3}, @AllocationType={4},@OperationType={5}",
        //                            seekerid, hld.ParkingSlotNumber, i, i, 1, 0);

        //                lsp.Add(new SeekerDetail()
        //                {
        //                    EmpNo = seekerid,
        //                    CreatedDate = i,
        //                    ParkingSlotNumber = hld.ParkingSlotNumber




        //                });





        //            }





        //            lhp.Add(new HolderPerson
        //            {
        //                EmpNo = hld.EmpNo,
        //                Startdate = i.ToString(),
        //                FirstName = usr.FirstName,
        //                LastName = usr.LastName,
        //                ParkingSlotNumber = hld.ParkingSlotNumber,
        //                OperationType = 1
        //            });


        //        }


        //    }

        //}
        #endregion
        public List<HolderPerson> Releaseslot(HolderPerson hld)
        {
            //HolderDetail holder = new HolderDetail();
            // SeekerDetail seeker = new SeekerDetail {CreatedDate = DateTime.Now};

            // List<HolderDetail> list = new List<HolderDetail>();
            // DateTime thisDay = DateTime.Today;
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;

            DateTime startDate = Convert.ToDateTime(hld.Startdate);

            DateTime endDate = Convert.ToDateTime(hld.Enddate);
            if (hld.Startdate != null && hld.Enddate!=null)
            {
                List<HolderPerson> ll= Multipleslotreleases(hld, startDate, endDate);
                return ll.ToList();
            }

            

                List<HolderDetail> list =
                    objectContext.HolderDetails.Where(h => h.EmpNo == hld.EmpNo && h.SlotReleasedDate == date)
                        .ToList();
            List<HolderPerson> lhp = new List<HolderPerson>();
            if (list.Count <= 0)
                {
                    var affectedRows =
                        objectContext.Database.ExecuteSqlCommand(
                            "sp_holderdatainsertion @EmpNo={0},@ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3},@AllocationType={4},@OperationType={5}",
                            hld.EmpNo, hld.ParkingSlotNumber, date, date, 0, 1);

                  //need to develop

                    int res = objectContext.Database.SqlQuery<int>("select dbo.Fn_SeekerInQuee()").First();
                    if (res > 0)
                    {
                    objectContext.Database.ExecuteSqlCommand("sp_CheckAndAllocateslote");
                    
                    }
                

                    int resdb = affectedRows == 1 ? 1 : 0;
                  hld.OperationType = 1;
                    hld.SeekerId = res.ToString();
                   lhp.Add(hld);
                    if (resdb == 1)
                    {
                       
                        sendmail(lhp);


                    }
                    return lhp;
                          

                }
            else
            {
                lhp.Add(new HolderPerson()
                {
                    OperationType = 0

                });

                return lhp;


            }
           

        }

        public void sendmail(List<HolderPerson> Lhp)
        {
            User usr;
            
                int empno = (int) Lhp[0].EmpNo;
                 usr = objectContext.Users.First(u => u.EmpNo == empno);
            
            
           
               
            string mailId = usr.UserLoginId;
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("smps366@gmail.com")
            };
            SmtpClient smtp = Clientcall();


            //recipient
            mail.To.Add(new MailAddress(mailId));

            mail.IsBodyHtml = true;
            
            System.Text.StringBuilder myStrBuilder = new System.Text.StringBuilder("Thank You " + usr.FirstName + "  For releasing your car parking slot No " +
                        usr.ParkingSlotNumber);
            myStrBuilder.Append("<br>");
            Lhp = Lhp.OrderByDescending(l => l.Startdate).ToList();

            foreach (HolderPerson hp in Lhp)
            {
                string strdate = hp.Startdate;
                myStrBuilder.Append(strdate);
                myStrBuilder.Append("<br>");
            }
            myStrBuilder.Replace("12:00:00 AM", "");

            myStrBuilder.Append("For any queries please contact help desk");

            mail.Body = myStrBuilder.ToString();
            smtp.Send(mail);






        }
        public SmtpClient Clientcall()
        {


            SmtpClient smtp = new SmtpClient
            {
                Port = 587,
                UseDefaultCredentials = true,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential("smps366@gmail.com", "smps123$"),
                Host = "smtp.gmail.com"
            };

            return smtp;


        }

        public void sendmail(List<SeekerDetail> lsp )
        {
            User usr;

            int empno = (int)lsp[0].EmpNo;
            string slotno = lsp[0].ParkingSlotNumber.ToString();
            usr = objectContext.Users.First(u => u.ParkingSlotNumber == slotno);
            string holderName = usr.FirstName + "" + usr.LastName;



            usr = objectContext.Users.First(u => u.EmpNo == empno);
            string mailId = usr.UserLoginId;
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("smps366@gmail.com")
            };
            SmtpClient smtp = Clientcall();
            mail.To.Add(new MailAddress(mailId));

            mail.IsBodyHtml = true;

            System.Text.StringBuilder myStrBuilder = new System.Text.StringBuilder("we are happy to inform That "+ holderName +" has Released his car parking slot No "+ lsp[0].ParkingSlotNumber+ " For The below Mentioned dates ");
           // lsp = lsp.OrderByDescending(l => l.CreatedDate).ToList();
           
            foreach (SeekerDetail hp in lsp)
            {
                string strdate = hp.CreatedDate.ToString();
                myStrBuilder.Append(strdate);
                myStrBuilder.Append("<br>");
            }
            myStrBuilder.Replace("12:00:00 AM", "");

            myStrBuilder.Append(" For any queries plz contact help desk");

            mail.Body = myStrBuilder.ToString();
            smtp.Send(mail);



        }







        public void Dispose()
        {
            objectContext.Dispose();
        }
    }
}

