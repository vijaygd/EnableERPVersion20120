using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using MySql.Data.MySqlClient;
using EnableIndia.App_Code.BAL;
using EnableIndia.App_Code.DAL;


/// <summary>
/// Summary description for CandidatesBAL
/// </summary>
namespace EnableIndia.App_Code.BAL
{
    public class CandidatesBAL
    {
        public CandidatesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region CANDIDATE PROPERTIES
        public int CandidateID
        {
            get;
            set;
        }

        public int EmployeeID
        {
            get;
            set;
        }

        public int CandidateFlagID
        {
            get;
            set;
        }

        public int NgoID
        {
            get;
            set;
        }

        public string CandidateNumberAtNGO
        {
            get;
            set;
        }

        public string RID
        {
            get;
            set;
        }

        public string SearchFor
        {
            get;
            set;
        }
        public string SearchIn
        {
            get;
            set;
        }
        public string FileNumber
        {
            get;
            set;
        }

        public string RegistrationDate
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public int DisabilityID
        {
            get;
            set;
        }

        public int DisabilitySubTypeID
        {
            get;
            set;
        }

        public string DateOfBirth
        {
            get;
            set;
        }
        public string ContractExpiryDate
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }

        public string PrimaryPhoneNumber
        {
            get;
            set;
        }

        public bool IsLastReachableOnPrimaryPhoneNumber
        {
            get;
            set;
        }

        public string SecondaryPhoneNumber
        {
            get;
            set;
        }

        public bool IsLastReachableOnSecondaryPhoneNumber
        {
            get;
            set;
        }

        public string PresentAddress
        {
            get;
            set;
        }

        public bool IsLastReachableOnPresentAddress
        {
            get;
            set;
        }

        public int PresentAddressStateID
        {
            get;
            set;
        }

        public int PresentAddressCityID
        {
            get;
            set;
        }

        public string PresentAddressPinCode
        {
            get;
            set;
        }

        public string PermanentAddress
        {
            get;
            set;
        }

        public bool IsLastReachableOnPermanentAddress
        {
            get;
            set;
        }

        public int PermanentAddressStateID
        {
            get;
            set;
        }

        public int PermanentAddressCityID
        {
            get;
            set;
        }

        public string PermanentAddressPinCode
        {
            get;
            set;
        }

        public string EmailAddress
        {
            get;
            set;
        }

        public bool AreAllRelevantDocumentSubmitted
        {
            get;
            set;
        }

        public string DocumentDetails
        {
            get;
            set;
        }

        public string MaritialStatus
        {
            get;
            set;
        }

        public bool IsBiodataHardCopySubmitted
        {
            get;
            set;
        }

        public bool IsBiodataSoftCopySubmitted
        {
            get;
            set;
        }

        public bool IsJoiningFormSigned
        {
            get;
            set;
        }

        public string UploadedPhotographExtension
        {
            get;
            set;
        }

        public string OldRegistrationNumber
        {
            get;
            set;
        }
        public string JoiningFormTypes
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string DateFrom
        {
            get;
            set;
        }

        public string DateTo
        {
            get;
            set;
        }

        public string IsProfiled
        {
            get;
            set;
        }

        public int EmploymentStatus
        {
            get;
            set;
        }

        public string Assignment
        {
            get;
            set;
        }

        public int StateID
        {
            get;
            set;
        }

        public int CityID
        {
            get;
            set;
        }

        public int AgeGroup
        {
            get;
            set;
        }

        public string CurrentDate
        {
            get;
            set;
        }

        public int RecommendedJobID
        {
            get;
            set;
        }

        public int RecommendedJobRoleID
        {
            get;
            set;
        }
        public string MissingDataProfile
        {
            get;
            set;
        }
        public string DateType
        {
            get;
            set;
        }

        public int GroupID
        {
            get;
            set;
        }

        public int LanguageID
        {
            get;
            set;
        }
        public int CompanyID
        {
            get;
            set;
        }
        public string RegistrationFrom
        {
            get;
            set;
        }
        public string RegistrationTo
        {
            get;
            set;
        }

        public string EmployentProjectStartDateFrom
        {
            get;
            set;
        }
        public string EmployentProjectStartDateTo
        {
            get;
            set;
        }

        public string EmployentProjectEndDateFrom
        {
            get;
            set;
        }

        public string EmployentProjectEndDateTo
        {
            get;
            set;
        }

        public decimal SalaryFrom
        {
            get;
            set;
        }

        public decimal SalaryTo
        {
            get;
            set;
        }

        public int TrainingProgramID
        {
            get;
            set;
        }
        public int TrainingProjectID
        {
            get;
            set;
        }
        public int EmploymentProjectID
        {
            get;
            set;
        }

        public int QualificationID
        {
            get;
            set;
        }

        #endregion

        public int GetCandidateID(string rid)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            return get.GetCandidateID(rid);
        }

        public DataTable GetRegistrationIDForFormPrinting(string candidateID)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            return get.GetRegistrationIDForFormPrinting(candidateID);
        }

        public DataTable GetAllActiveRegisteredCandidate(EnableIndia.App_Code.BAL.CandidatesBAL cand)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            DataTable dtAllActive = get.GetAllActiveRegisteredCandidate(cand);

            foreach (DataRow dr in dtAllActive.Rows)
            {
                if (!System.DBNull.Value.Equals(dr["phone_numbers"]))
                {
                    dr["phone_numbers"] = dr["phone_numbers"].ToString().Replace(",", Environment.NewLine);
                }
                else
                {
                    dr["phone_numbers"] = "99999999";
                }
                if (dr["unemployed_since_days"].ToString().Equals("Employed"))
                    {
                        //dr["recommended_job_types"] = "";
                        //dr["recommended_job_roles"] = "";
                        dr["recommended_job_types"] = dr["recommended_job_types"].ToString();
                        dr["recommended_job_roles"] = dr["recommended_job_roles"].ToString();
                        dr["company_name"] = dr["company_name"].ToString();
                        dr["designation"] = dr["designation"].ToString();
                        dr["role_name"] = dr["role_name"].ToString();
                    }

                    else
                    {
                        dr["recommended_job_types"] = dr["recommended_job_types"].ToString();
                        dr["recommended_job_roles"] = dr["recommended_job_roles"].ToString();
                        dr["company_name"] = "";
                        dr["designation"] = "";
                        dr["role_name"] = "";
                    }
                }
            return dtAllActive;
        }

        public string GetRIDForCandidate(bool isEnableIndiaCandidate, bool wantRIDSpaceSeparated)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            string rID = get.GetRIDForCandidate(isEnableIndiaCandidate);

            if (wantRIDSpaceSeparated.Equals(false))
            {
                return rID;
            }
            else
            {
                char[] array = rID.ToCharArray();
                string spaceSeparatedRID = "";
                for (int counter = 0; counter < array.Length; counter++)
                {
                    if (counter.Equals(0))
                    {
                        spaceSeparatedRID += array[counter].ToString();
                    }
                    else
                    {
                        spaceSeparatedRID += array[counter].ToString() + " ";
                    }
                }
                return spaceSeparatedRID;
            }
        }

        public MySqlDataReader GetCandidateDetails(string candidateID)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            return get.GetCandidateDetails(candidateID);
        }

        public DataTable GetUnregisteredCandidates()
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            return get.GetUnregisteredCandidates();
        }

        public DataTable GetListOfCandidates(string employmentStatus)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            return get.GetListOfCandidates(employmentStatus);
        }

        public string CreateUnregisteredCandidates(string numberOfForms, string candidateNgoID, out string errorMessage)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            return get.CreateUnregisteredCandidates(numberOfForms, candidateNgoID, out errorMessage);
        }

        public int CreateRegisteredCandidate(EnableIndia.App_Code.BAL.CandidatesBAL cand)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
           
            return get.CreateRegisteredCandidate(cand);
        }
        //public bool UpdateCandidate(CandidatesBAL cand)
        //{
        //    CandidatesDAL get = new CandidatesDAL();
        //    int rowsAffected = get.UpdateCandidate(cand);
        //    if (rowsAffected > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public bool UpdateCandidate(CandidatesBAL cand)
        {
           
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            // EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            int rowsAffected = get.UpdateCandidate(cand);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UploadCandidatePhoto(FileUpload FuUploadPhoto, int candidateID)
        {
            if (!FuUploadPhoto.PostedFile.FileName.Equals(""))
            {
                string fileExtension = Path.GetExtension(FuUploadPhoto.PostedFile.FileName);
                //---modified on 15-5-2012
                MySqlDataReader Reader = null;
                string Rid = "";
                CandidateFlagsBAL candid = new CandidateFlagsBAL();
                Reader = candid.GetRegisteredId(candidateID);
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Rid = Reader.GetValue(0).ToString();
                    }
                }
                Reader.Close();
                string registeredID = Rid;
                //---modified on 15-5-2012
                //---modified on 15-5-2012
                //string encryptedcandidateID = Global.EncryptID(candidateID).ToString().Replace(".", "");
                //string filePath = HttpContext.Current.Server.MapPath("~/Photographs/cand_") + encryptedcandidateID + fileExtension;
                //---modified on 15-5-2012
                string filePath = HttpContext.Current.Server.MapPath("~/Photographs/Thumbnails/cand_") + registeredID + fileExtension;
                //Saves image in original size
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                //---modified on 15-5-2012
                //FuUploadPhoto.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("~/Photographs/cand_") + encryptedcandidateID + fileExtension);
                FuUploadPhoto.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("~/Photographs/Thumbnails/cand_") + registeredID + fileExtension);
                //---modified on 15-5-2012
                //Saves thumbnail
                System.Drawing.Image imgPhoto = System.Drawing.Image.FromStream(FuUploadPhoto.PostedFile.InputStream);
                System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                System.Drawing.Image imgThumbnail = imgPhoto.GetThumbnailImage(101, 108, myCallback, IntPtr.Zero);

                //---modified on 15-5-2012
                //string thumbnailPath = HttpContext.Current.Server.MapPath("~/Photographs/Thumbnails/cand_") + encryptedcandidateID + fileExtension;

                string thumbnailPath = HttpContext.Current.Server.MapPath("~/Photographs/Thumbnails/cand_") + registeredID + fileExtension;
                //---modified on 15-5-2012
                if (File.Exists(thumbnailPath))
                {
                    File.Delete(thumbnailPath);
                }
                imgThumbnail.Save(thumbnailPath);
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        public string GetCandidatePhotoPath(int candidateID, string fileExtension)
        {
            MySqlDataReader Reader = null;
            string Rid = "";
            CandidateFlagsBAL candid = new CandidateFlagsBAL();
            Reader = candid.GetRegisteredId(candidateID);
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Rid = Reader.GetValue(0).ToString();
                }
            }
            Reader.Close();
            string registeredID = Rid;
            //string encryptedcandidateID = Global.EncryptID(candidateID).ToString().Replace(".", "");
            return "~/Photographs/Thumbnails/cand_" + registeredID + fileExtension;
        }

        public int CheckDuplicationOfOldRegistrationNumber(CandidatesBAL cand)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            return get.CheckDuplicationOfOldRegistrationNumber(cand);
        }

        public int CheckDuplicationCandidateDetails(CandidatesBAL cand)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            return get.CheckDuplicationCandidateDetails(cand);
        }

        public DataTable GetCandidateTasks(CandidatesBAL cand)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
           
            DataTable dtGetCandidateTasks = get.GetCandidateTasks(cand);
            dtGetCandidateTasks.Columns.Add("str_closure_date");
            dtGetCandidateTasks.Columns.Add("str_follow_up_date");
            dtGetCandidateTasks.Columns.Add("str_lead_time_close_days");
            foreach (DataRow dr in dtGetCandidateTasks.Rows)
            {
                if (dr["follow_up_date"].ToString().Contains("1900"))
                {
                    dr["str_follow_up_date"] = "";
                }
                else
                {
                    dr["str_follow_up_date"] = Convert.ToDateTime(dr["follow_up_date"]).ToString(Global.GetDateFormat());
                }

                if (dr["closure_date"].ToString().Contains("1900"))
                {
                    dr["str_closure_date"] = "";
                    dr["str_lead_time_close_days"] = "";
                }
                else
                {
                    dr["str_lead_time_close_days"] = dr["lead_time_close_days"].ToString();
                    dr["str_closure_date"] = Convert.ToDateTime(dr["closure_date"]).ToString(Global.GetDateFormat());
                }
            }
            return dtGetCandidateTasks;
        }

        public DataTable GetOwnerwiseOpenCandidateTask(CandidatesBAL cand)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            return get.GetOwnerwiseOpenCandidateTask(cand);
        }

        public DataTable GetOwnerwiseClosedCandidateTask(CandidatesBAL cand)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            return get.GetOwnerwiseClosedCandidateTask(cand);
        }
        public int GetCandidateIDFromRID(string RID)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            return get.GetCandidateIDFromRID(RID);
        }

        public DataTable GetEmploymentProofNotGotCandidates()
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            DataTable dtCandidate = get.GetEmploymentProofNotGotCandidates();
            foreach (DataRow dr in dtCandidate.Rows)
            {
                dr["phone_numbers"] = dr["phone_numbers"].ToString().Replace(",", Environment.NewLine);

            }
            return dtCandidate;
        }
        public DataTable GetRejectionDataFroCandidates(CandidatesBAL cand)
        {
            EnableIndia.App_Code.DAL.CandidatesDAL get = new EnableIndia.App_Code.DAL.CandidatesDAL();
            DataTable dtCandidate = get.GetRejectionDataFroCandidates(cand);
            return dtCandidate;
        }
    }
}
