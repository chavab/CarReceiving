using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfCarTestProd.CarApp;

namespace WcfCarTestProd
{
    [TestClass]
    public class UnitTest1
    {
        private static ServiceClient service;
        public TestContext oTestContext { get; set; }
        [AssemblyInitialize]
        public static void init(TestContext testContext)
        {
            service = new ServiceClient("NetTcpBinding_IService");
            //service = new ServiceClient("NetTcpBinding_IService");
            testContext.WriteLine("In AssemblyInitialize");
        }

        [TestMethod]
        public void TestMethod1()
        {
            try
            {

                var userName = "chava";
                var userpass = "chava12";
                // var userpass = ChampEncryption.Encryptor.encrypt("chava1234");
                var exMessage = "";
                STATUS_CODES statusCode;
                //string statusCode;
                var loginDetails = service.Login(userName, userpass, out statusCode, out exMessage);
            // //   Login();
            //    //  var isSuccess = service.CheckMigrashStatus();
            //    //  var token = service.LoginMigrash(out statusCode, out exMessage);
            //    //   var valid = service.TokenAuthorization(token);
                var respons = service.GetResponsibilities(loginDetails.Token, out statusCode, out exMessage);

                var cars = service.GetCarsForControl(loginDetails.Token, out statusCode, out exMessage);


            //    var car = service.GetCarForControlDetails(loginDetails.Token, cars[0].LicenceNum, out statusCode, out exMessage);
            //    var comments = service.GetComments(loginDetails.Token, car.LicenceNum, out statusCode, out exMessage);
            //    var comment = service.InsertComment(loginDetails.Token, car.LicenceNum, "4545", out statusCode, out exMessage);

            //    var temp = "";
            //    var damages = service.GetDamages(loginDetails.Token, out statusCode, out exMessage);
            //    foreach (var item in damages)
            //    {
            //        var da = item.DamageDesc;
            //    }


            //    var isUn = service.SetKM(loginDetails.Token, "321", 50, car.Mutag, out statusCode, out exMessage);
            //    if (isUn = false)
            //    {

            //    }
            //    var shipments = service.GetShipments(loginDetails.Token, out statusCode, out exMessage);
            //    //    var cars = service.GetCarsByShipment(loginDetails.Token, shipments.First().ShippingNumber, out statusCode, out exMessage);
            //    //    var aa = service.ConfirmCarReception(loginDetails.Token, shipments.First().ShippingNumber, cars.First().LicenseNumber, out statusCode, out exMessage);

            //    //   var tt = service.GetDelivaryDetails(loginDetails.Token,"37306602", CustomerType.ContractCustomer, out statusCode, out exMessage);
            //    //    var rr = tt.ContractFormat;
            //    //   var shipments = service.GetShipments(loginDetails.Token, out statusCode, out exMessage);
            //    //      var cars2 = service.GetCarsByShipment(loginDetails.Token, shipments[5].ShippingNumber, out statusCode, out exMessage);
            //    //    var car1 = cars.Last().LicenseNumber;
            //    //      var carManually = service.CarManuallyToShipment(loginDetails.Token, 159740, "3333333", out statusCode, out exMessage);
            //    //      cars = service.GetCarsByShipment(loginDetails.Token, shippingNum, out statusCode, out exMessage);
            //    //      carManually = service.CarManuallyToShipment(loginDetails.Token, shippingNum, car, out statusCode, out exMessage);
            //    //      cars = service.GetCarsByShipment(loginDetails.Token, shippingNum, out statusCode, out exMessage);



            //    var xx = service.GetCarsForDelivery(loginDetails.Token, out statusCode, out exMessage);
            //    byte[] imageArray = System.IO.File.ReadAllBytes(@"C:\Users\Public\Picture\Car.png");
            //    string base64 = Convert.ToBase64String(imageArray);
            //    var cc = service.GetDelivaryDetails(loginDetails.Token, "37635702", CustomerType.ContractCustomer, out statusCode, out exMessage);
            //    service.UploadDocumentFile(loginDetails.Token, base64, EDocumentType.CarInsurance, cc.Mutag, cc.Dealer, cc.Contract, cc.ReleaseCondition, out statusCode, out exMessage);
            //    service.UploadDocumentFile(loginDetails.Token, base64, EDocumentType.Licence, cc.Mutag, cc.Dealer, cc.Contract, cc.ReleaseCondition, out statusCode, out exMessage);

            //    //   var dd = carDal.UploadDocumentFile(loginDetails.Token, base64, EDocumentType.LicenceNumber, cc.Mutag, cc.Dealer, cc.Contract, cc.ReleaseCondition, out statusCode, out exMessage);
            //    var ins = service.GetInsuranceCompanies(loginDetails.Token, out statusCode, out exMessage);
            //    cc.SelectedInsuranceCode = 11;
            //    cc.SecondNumber = 888;
            //    cc.KmNum = 55;
            //    cc.InsurancePolicyNumber = 666;
            //    cc.DeliveryComment = "aaaa";
            //    var url = "";

            //    var isSuc = service.AcceptCarForDelivery(loginDetails.Token, cc, out statusCode, out exMessage);
            //    var a1 = service.GetDeliveryPdf(loginDetails.Token, cc, out statusCode, out exMessage);
            //    var suc = service.SaveDeliverySignature(loginDetails.Token, cc, "", base64, out statusCode, out exMessage);


            //    var licence = cars[0].LicenceNum;
            //    var carValid = service.GetCarForValidation(loginDetails.Token, licence, out statusCode, out exMessage);
            //    var template = service.GetMailTemplate(loginDetails.Token, EmailType.Damage, licence, shipments[0].ShippingNumber, out statusCode, out exMessage);
            //    template = service.GetMailTemplate(loginDetails.Token, EmailType.Status, licence, shipments[0].ShippingNumber, out statusCode, out exMessage);
            //    var sendmail = service.SendDamageEmail(loginDetails.Token, licence, shipments[0].ShippingNumber, "שריטה בדלת הימנית", template, base64, out statusCode, out exMessage);
            //    var carReject = service.RejectCarReception(loginDetails.Token, shipments[0].ShippingNumber, cars[0].LicenceNum, out statusCode, out exMessage);
            //    // var carManually = service.CarManuallyToShipment(loginDetails.Token, shipments.First().ShippingNumber, cars.Last().LicenseNumber, out statusCode, out exMessage);
            //    template = service.GetMailTemplate(loginDetails.Token, EmailType.Status, licence, shipments[0].ShippingNumber, out statusCode, out exMessage);
            //    var sendmail1 = service.SendEmail(loginDetails.Token, licence, shipments[0].ShippingNumber, template, out statusCode, out exMessage);
            }
            catch (Exception ex)
            {


            }



        }

        public string Login()
        {
            var errorMessage = "";
            var statusCode = STATUS_CODES.SUCCESS;
            try
            {

                //  var user=ConfigurationManager.AppSettings["NezakimUser"];
                //  var password=ConfigurationManager.AppSettings["NezakimPassword"]; 
                var user = "MGPMOSER";
                var password = "abc123";

                ServiceChannel.CheckStatus();
              var reas=  ServiceChannel.GetService.GetReasonsForDelivery();
              var a = reas[0];
                string token = ServiceChannel.GetService.Login(user, password);
                return token;


                if (statusCode == STATUS_CODES.FAIL)
                {
                    errorMessage = "תקלה בהתחברות למגרש";
                    return "";
                }
            }
            catch (Exception ex)
            {
                statusCode = STATUS_CODES.FAIL;
                errorMessage = "תקלה בהתחברות למגרש";

            }
            return "";
        }
    }
}
