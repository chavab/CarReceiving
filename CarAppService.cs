using CarReceivingApp;
using CarReceivingApp.Prototypes;
using ClsUtil;
using PresenterCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WCFPresenterService;

namespace WCFCarReceivingAppTest
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class CarAppService : IService
    {
        private CarReceivingBL CarDal = new CarReceivingBL();
      

        public CarByShipment CarManuallyToShipment(string token, int shippingNumber, string licenseNumber, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.CarManuallyToShipment(token, shippingNumber, licenseNumber, out statusCode, out errorMessage);
        }

        public bool ConfirmCarReception(string token, int shippingNumber, string licenseNumber, out STATUS_CODES statusCode, out string errorMessage)
        {
           return CarDal.ConfirmCarReception(token, shippingNumber, licenseNumber, out statusCode, out errorMessage);
        }

        public bool DeleteDocumentFile(string token, string imageBase64, EDocumentType docType, int contractId, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.DeleteDocumentFile(token, imageBase64, docType, contractId, out statusCode, out errorMessage);
        }

        public CarForValidation GetCarForValidation(string token, string licenceNumber, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetCarForValidation(token, licenceNumber, out statusCode, out errorMessage);
        }

        public List<CarByShipment> GetCarsByShipment(string token, int shippingNumber, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetCarsByShipment(token, shippingNumber, out statusCode, out errorMessage);
        }

        public List<CarForDelivery> GetCarsForDelivery(string token, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetCarsForDelivery(token, out statusCode, out errorMessage);
        }

        public CarDeliveryDetails GetDelivaryDetails(string token, string licenseNumber, CustomerType cusType, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetDelivaryDetails(token, licenseNumber, cusType, out statusCode, out errorMessage);
        }

        public Dictionary<int, string> GetInsuranceCompanies(string token, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetInsuranceCompanies(token, out statusCode, out errorMessage);
        }

        public List<ShipmentDetails> GetShipments(string token, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetShipments(token, out statusCode, out errorMessage);
        }


        public LoginDetails Login(string userName, string password, out STATUS_CODES statusCode, out string errorMessage)
        {
            var loginDetails=CarDal.Login(userName, password, out statusCode,out errorMessage);
            if (statusCode == STATUS_CODES.FAIL)
            {
                RestartService();
                Login(userName, password, out statusCode, out errorMessage);
            }
            var proc = new AccessToProcFunc.ProcAccessFunc();
            return loginDetails;
        }

        public bool RejectCarReception(string token, int shippingNumber, string licenseNumber, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.RejectCarReception(token, shippingNumber, licenseNumber, out statusCode, out errorMessage);
        }

        public bool SendDamageEmail(string token, string licenceNumber, int shippingNum, string damageDescription, string mailBody, string imageBase64, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.SendDamageEmail(token, licenceNumber,shippingNum, damageDescription, mailBody, imageBase64, out statusCode, out errorMessage);
        }

        public bool SendEmail(string token, string licenceNumber, int shippingNum, string mailBody, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.SendEmail(token, licenceNumber,shippingNum, mailBody, out statusCode, out errorMessage);
        }


        public string GetDeliveryPdf(string token, CarDeliveryDetails carDetails, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetDeliveryPdf(token,  carDetails,out statusCode, out  errorMessage);

        }

        public InitDetails GetInit(string token, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetInit(token, out statusCode, out  errorMessage);

        }

        public bool AcceptCarForDelivery(string token, CarDeliveryDetails carDetails, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.AcceptCarForDelivery(token, carDetails, out statusCode, out errorMessage);

        }

        public bool ConfirmCarControl(string token, CarForControlDetails car, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.ConfirmCarControl(token, car, out statusCode, out errorMessage);
        }

     
        public bool GetCarDamageCount(string token, string licenceNum, out STATUS_CODES statusCode, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public CarForControlDetails GetCarForControlDetails(string token, string licenceNum, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetCarForControlDetails(token, licenceNum, out statusCode, out errorMessage);

        }

        public List<LocalAddition> GetCarLocalAdditions(string token, string licenceNum, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetCarLocalAdditions(token, licenceNum, out statusCode, out errorMessage);

        }

        public List<Comment> GetComments(string token, string licenceNum, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetComments(token, licenceNum, out  statusCode, out  errorMessage);
        }

        public string GetMailTemplate(string token, EmailType emailType, string licenceNum,int shippingNum, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetMailTemplate(token, emailType,licenceNum,shippingNum, out statusCode, out errorMessage);

        }

        public Dictionary<int, string> GetSpareTireOption(string token, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetSpareTireOption(token, out statusCode, out errorMessage);

        }

        public string LoadDocumentFile(string token, EDocumentType docType, int contractId, out STATUS_CODES statusCode, out string errorMessage)
        {
            throw new NotImplementedException();
            //return CarDal.LoadDocumentFile(token, docType, contractId,out statusCode, out errorMessage);
        }

        public bool SaveDeliverySignature(string token, CarDeliveryDetails car,string imageBase64Moser,string imageBase64Cus, out STATUS_CODES statusCode, out string errorMessage)
        {
           return CarDal.SaveDeliverySignature(token, car, imageBase64Moser, imageBase64Cus, out statusCode, out errorMessage);
        }


        public bool UploadDocumentFile(string token, string imageBase64, EDocumentType docType, string mutag, string dealer, int contractId, string releaseCond, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.UploadDocumentFile(token, imageBase64, docType,  mutag,  dealer,  contractId,  releaseCond, out statusCode, out errorMessage);

        }



        public bool CheckStatus()
        {
           return CarDal.CheckStatus();
        }


        public List<CarForControl> GetCarsForControl(string token, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetCarsForControl(token, out statusCode,out errorMessage);
        }


        public bool SetKM(string token, string LicenceNum, int KM, string mutag, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.SetKM(token, LicenceNum, KM, mutag, out statusCode, out errorMessage );
        }


        public bool ConfirmKM(string token, string LicenceNum, string ConfirmName, out STATUS_CODES statusCode, out string errorMessage)
        {
          return CarDal.ConfirmKM(token,  LicenceNum,  ConfirmName, out  statusCode, out  errorMessage);
        }

        public bool InsertComment(string token, string licenceNum, string comment, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.InsertComment(token, licenceNum, comment, out  statusCode, out  errorMessage);
        }


        public List<Prototypes.DataContracts.DamageOut> GetDamages(string token, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetDamages(token, out  statusCode, out  errorMessage);
        }

        public List<Prototypes.DataContracts.Reason> GetReasons(string token, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetReasons(token, out  statusCode, out  errorMessage);
        }

        public List<Prototypes.DataContracts.Responsibilty> GetResponsibilities(string token, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetResponsibilities(token, out  statusCode, out  errorMessage);
        }
        public List<Prototypes.DataContracts.Position> GetPositions(string token, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetPositions(token, out  statusCode, out  errorMessage);
        }

        public Prototypes.DataContracts.SaveResult SaveDamage(string token, string BrandAndVehicle, string Chassis, string DamageId, string PositionId,
                                 string ReasonId, string ResponsibilityId, string Comment, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.SaveDamage(token, BrandAndVehicle, Chassis, DamageId, PositionId, ReasonId, ResponsibilityId, Comment, out statusCode, out errorMessage);
        }

        public void SaveMediaFiles(string token, string damage, string brand, string vehicle, string position, List<byte[]> files, out STATUS_CODES statusCode, out string errorMessage)
        {
            CarDal.SaveMediaFiles(token, damage, brand, vehicle, position, files, out statusCode, out errorMessage);
        }
        public List<Prototypes.DataContracts.HistoryDamage> GetHistoryDamage(string token, string brandAndVehicle, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetHistoryDamage(token, brandAndVehicle, out statusCode, out errorMessage);
        }
        public List<Prototypes.DataContracts.Media> GetMediaForDamage(string token, string damage, string brand, string vehicle, string position, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetMediaForDamage(token, damage, brand, vehicle, position, out statusCode, out errorMessage);
        }
        public Prototypes.DataContracts.SaveResult ConfirmSelectDamage(Prototypes.DataContracts.ParamsForConfirmSelectDamage damage, string token, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.ConfirmSelectDamage(damage, token, out statusCode, out errorMessage);
        }
        public List<Prototypes.DataContracts.DamageForDeliveryConfirm> GetDamageCNF(string token, string brandAndVehicle, out STATUS_CODES statusCode, out string errorMessage)
        {
            return CarDal.GetDamageCNF(token, brandAndVehicle, out statusCode, out errorMessage);
        }

        private void RestartService()
        {
            try
            {
              ((Logger)ClsUtil.ClsUtil.Logger).Trace(" start RestartService because of error connection");

                WCFRestartServices.RestartServices reset = new WCFRestartServices.RestartServices();
                reset.ControlService("champ-services", "WCFCarReceivingAppTest", ServiceControllerStatus.Running);       
            }
            catch (Exception ex)
            {
                ((Logger)ClsUtil.ClsUtil.Logger).Fatal(" error when restartService" + ex);

            }
        }
    }
}
