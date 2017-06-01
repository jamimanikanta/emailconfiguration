using Smps.Core.Interfaces.Seeker.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using System.Net.Mail;
using Smps.Core.BusinessObjects.Seeker;

namespace Smps.Infrastructure.Data.Repositories
{
    public class SeekerServiceRepository : ISeekerServiceRepository
    {
        private readonly MYEntity objectContext = new MYEntity();
        public object RequestForSlot(int empNo)
        {
            // HolderDetail holder = new HolderDetail();
            // List<HolderDetail> Hlist = new List<HolderDetail>();
            SeekerDetail seeker = new SeekerDetail
            {
                EmpNo = empNo,
                CreatedDate = DateTime.Now
            };



            //List<User> list = new List<User>();
            //DateTime thisDay = DateTime.Now;
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;

            //var seekerdateAndTime = DateTime.Now;
            //var seekerdate = dateAndTime.Date;


            // var dbContextTransaction = objectContext.Database.BeginTransaction();

            List<HolderDetail> hlist =
                objectContext.HolderDetails.Where(h => h.OperationType == 1 && h.CreatedDate == date).ToList();
            List<SeekerDetail> slist =
                objectContext.SeekerDetails.Where(
                    s =>
                        s.OperationType == 1 && s.CreatedDate.Day == date.Day && s.CreatedDate.Year == date.Year &&
                        s.CreatedDate.Month == date.Month).ToList();

            IEnumerable<HolderDetail> eh = hlist;
            IEnumerable<SeekerDetail> esd = slist;
            User usr = objectContext.Users.Single(u => u.EmpNo == empNo);
            Dictionary<string, string> dictionary = null;
            if (usr != null)
            {
                int output;
                //string seekeroutputmessage;
                seeker.EmpNo = usr.EmpNo;
                List<SeekerDetail> skr;
                string currentdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime dt = DateTime.ParseExact(currentdate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                seeker.CreatedDate = dt;

                if (eh.Any() && !esd.Any())
                {
                    skr =
                        objectContext.SeekerDetails.Where(
                            s =>
                                s.EmpNo == seeker.EmpNo && s.CreatedDate.Year == seeker.CreatedDate.Year &&
                                s.CreatedDate.Month == seeker.CreatedDate.Month &&
                                s.CreatedDate.Day == seeker.CreatedDate.Day).ToList();
                    IEnumerable<SeekerDetail> e6 = skr;
                    if (!e6.Any())
                    {
                        var parameter = hlist[0].EmpNo;
                        if (parameter != null)
                        {
                            int empno = (int)parameter;
                            //holder updation allocation and operation type
                            objectContext.Database.ExecuteSqlCommand("sp_UpdatingOperationaAndAllocation @EmpNo={0},@CreatedDate={1}", parameter, hlist[0].CreatedDate);
                            User holderUser = objectContext.Users.SingleOrDefault(u => u.EmpNo == empno);
                            if (holderUser != null)
                            {
                                int psn = Convert.ToInt32(holderUser.ParkingSlotNumber);
                                //check once working r not





                                objectContext.Database.ExecuteSqlCommand(
                                    "sp_seekerdetails @EmpNo={0}, @ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3}, @AllocationType={4},@OperationType={5}",
                                    seeker.EmpNo, psn, seeker.CreatedDate, seeker.CreatedDate, 1, 0);
                            }
                        }
                        SeekerDetail sl =
                            objectContext.SeekerDetails.SingleOrDefault(
                                s =>
                                    s.EmpNo == seeker.EmpNo && s.CreatedDate.Year == seeker.CreatedDate.Year &&
                                    s.CreatedDate.Month == seeker.CreatedDate.Month &&
                                    s.CreatedDate.Day == seeker.CreatedDate.Day);


                        if (sl != null)
                        {
                            output = sl.SeekerDetailId;
                            dictionary = new Dictionary<string, string>
                            {
                                {"Type", "6"},
                                {"FirstName", usr.FirstName},
                                {"LastName", usr.LastName},
                                {"ParkingSlotNumber", sl.ParkingSlotNumber},
                                {"Reference", output.ToString()}
                            };
                            //seekeroutputmessage = "Hello" + usr.FirstName + "" + usr.LastName + "You had Allocated having slot Number:" + sl.ParkingSlotNumber + " with Reference Number:" + output;
                            Sendmail(6, seeker.EmpNo, sl.ParkingSlotNumber, output);
                        }
                        return dictionary;



                    }
                    else
                    {
                        List<SeekerDetail> sl =
                            objectContext.SeekerDetails.Where(
                                s =>
                                    s.EmpNo == seeker.EmpNo && s.CreatedDate.Year == seeker.CreatedDate.Year &&
                                    s.CreatedDate.Month == seeker.CreatedDate.Month &&
                                    s.CreatedDate.Day == seeker.CreatedDate.Day).ToList();
                        // IEnumerable<SeekerDetail> e7 = sl;
                        // int count = e7.Count();

                        // output = sl[0].SeekerDetailId;
                        dictionary = new Dictionary<string, string>
                        {
                            {"Type", "7"},
                            {"FirstName", usr.FirstName},
                            {"LastName", usr.LastName},
                            {"ParkingSlotNumber", sl[0].ParkingSlotNumber}
                        };
                        // " sorry" + usr.FirstName + "" + usr.LastName + "You already raised a Request Today and Your Slot Number is" + sl[0].ParkingSlotNumber;
                        Sendmail(7, seeker.EmpNo, sl[0].ParkingSlotNumber, null);
                        return dictionary;



                    }

                }
                else
                {
                    skr =
                        objectContext.SeekerDetails.Where(
                            s =>
                                s.EmpNo == seeker.EmpNo && s.CreatedDate.Year == seeker.CreatedDate.Year &&
                                s.CreatedDate.Month == seeker.CreatedDate.Month &&
                                s.CreatedDate.Day == seeker.CreatedDate.Day).ToList();
                    IEnumerable<SeekerDetail> es = skr;
                    // int totalcount = es.Count();

                    if (!es.Any())
                    {




                        objectContext.Database.ExecuteSqlCommand(
                            "sp_seekerdetails @EmpNo={0}, @ParkingSlotNumber={1},@CreatedDate={2},@SlotReleasedDate={3}, @AllocationType={4},@OperationType={5}",
                            seeker.EmpNo, null, seeker.CreatedDate, seeker.CreatedDate, 0, 1);
                        List<SeekerDetail> sl =
                            objectContext.SeekerDetails.Where(
                                s =>
                                    s.EmpNo == seeker.EmpNo && s.CreatedDate.Year == seeker.CreatedDate.Year &&
                                    s.CreatedDate.Month == seeker.CreatedDate.Month &&
                                    s.CreatedDate.Day == seeker.CreatedDate.Day).ToList();
                        IEnumerable<SeekerDetail> esl = sl;
                        int count = esl.Count();

                        output = sl[count - 1].SeekerDetailId;
                        dictionary = new Dictionary<string, string>
                        {
                            {"Type", "8"},
                            {"FirstName", usr.FirstName},
                            {"LastName", usr.LastName},
                            {"Reference", output.ToString()}
                        };
                        //seekeroutputmessage = "Hello" + usr.FirstName + "" + usr.LastName + "Thank you for request a slot You are Under waiting list with Reference Number:" + output;
                        Sendmail(8, seeker.EmpNo, null, output);
                        return dictionary;

                    }
                    else
                    {
                        if (skr[0].ParkingSlotNumber == null)
                        {
                            dictionary = new Dictionary<string, string>
                            {
                                {"Type", "9"},
                                {"FirstName", usr.FirstName},
                                {"LastName", usr.LastName},
                                {"Reference", skr[0].SeekerDetailId.ToString()}
                            };
                            //seekeroutputmessage = "Hello" + usr.FirstName + "" + usr.LastName + "Thank you for request a slot You are Under waiting list with Reference Number:" + skr[0].SeekerDetailId;
                            Sendmail(9, seeker.EmpNo, skr[0].ParkingSlotNumber, skr[0].SeekerDetailId);
                            return dictionary;
                        }
                        else
                        {
                            dictionary = new Dictionary<string, string>
                            {
                                {"Type", "10"},
                                {"FirstName", usr.FirstName},
                                {"LastName", usr.LastName},
                                {"ParkingSlotNumber", skr[0].ParkingSlotNumber}
                            };
                            //" sorry" + usr.FirstName + "" + usr.LastName + "You already raised a Request Today and Your Slot Number is" + skr[0].ParkingSlotNumber;
                            Sendmail(10, seeker.EmpNo, skr[0].ParkingSlotNumber, null);
                            return dictionary;
                        }




                    }

                }

            }
            else
            {
                dictionary = new Dictionary<string, string> { { "Type", "404" } };
                //"there is no that type of user";
                return dictionary;
            }
        }
        public void Sendmail(int type, int? hld, string slotno, int? refNo)
        {
            using (MYEntity objectContext = new MYEntity())
            {

                User usr = objectContext.Users.Single(u => u.EmpNo == hld);
                string mailId = usr.UserLoginId;
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("smps366@gmail.com")
                };
                SmtpClient smtp = new SmtpClient
                {
                    Port = 587,
                    UseDefaultCredentials = true,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential("smps366@gmail.com", "smps123$"),
                    Host = "smtp.gmail.com"
                };


                //recipient
                mail.To.Add(new MailAddress(mailId));

                mail.IsBodyHtml = true;

                string st;

                switch (type)
                {

                    case 6:
                        st = "Hello" + usr.FirstName + "" + usr.LastName + "You had Allocated having slot Number:" + slotno + " with Reference Number:" + refNo;

                        break;
                    case 7:
                        st = " sorry" + usr.FirstName + "" + usr.LastName + "You already raised a Request Today and Your Slot Number is" + slotno;

                        break;
                    case 8:
                        st = "Hello" + usr.FirstName + "" + usr.LastName + "Thank you for request a slot You are Under waiting list with Reference Number:" + refNo;

                        break;
                    case 9:
                        st = "Hello" + usr.FirstName + "" + usr.LastName + "Thank you for request a slot You are Under waiting list with Reference Number:" + refNo;

                        break;
                    case 10:
                        st = " sorry" + usr.FirstName + "" + usr.LastName + "You already raised a Request Today and Your Slot Number is" + slotno;

                        break;
                    default:
                        st = "plz Ignore";
                        break;
                }









                mail.Body = st;
                smtp.Send(mail);



            }




        }

        public List<SeekerPerson> CheckSeekersElgibility(string userId, DateTime begindate, DateTime enddate)
        {
            List<SeekerPerson> Seekerperson = new List<SeekerPerson>();


            List<SeekerDetail> Seekerlist = new List<SeekerDetail>();

            var sdateAndTime = begindate;
            var sdate = sdateAndTime.Date;
            int id = Convert.ToInt32(userId);
            var edateAndTime = enddate;
            var edate = edateAndTime.Date;

            Seekerlist = objectContext.SeekerDetails.Where(s => s.EmpNo == id).ToList();

            Seekerlist = Seekerlist.FindAll(h => h.CreatedDate >= begindate).ToList();
            Seekerlist = Seekerlist.FindAll(h => h.CreatedDate <= enddate).ToList();

            if (Seekerlist.Any())

            {
                foreach (SeekerDetail seekerDetail in Seekerlist)
                {
                    SeekerPerson seeker = new SeekerPerson();
                    seeker.CreatedDate = seekerDetail.CreatedDate;
                    Seekerperson.Add(seeker);
                }



            }

            





            return Seekerperson.ToList();





        }






    }
}
