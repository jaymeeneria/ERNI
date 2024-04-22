using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechExam3.Controllers;
using TechExam3.Interface;
using TechExam3.Model;
using TechExam3.Valicator;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace UnitTesting.Validator
{
    [TestClass]
    public class EmployeeValidatorTest 
    {
        EmployeeValidator _validator;
        AddEmployeeRequest _addEmployeeRequest;
        EditEmployeeRequest _editEmployeeRequest;

        [TestInitialize]
        public void Setup()
        {
            _validator = new EmployeeValidator();
        }

        [TestMethod]
        public void ValidateRequest_AddEmployee_NameWithValidInput_ReturnErrorFalse()
        {
            _addEmployeeRequest = new AddEmployeeRequest
            {
                Name = "Jaymee",
                Position = "Full Stack Dev",
                Email = "Email",
                PhoneNumber = "09123456789",
                Address = "Address"
            };

            ValidatorResponse response = _validator.ValidateRequest(_addEmployeeRequest);

            Assert.IsFalse(response.HasError);
            Assert.AreEqual(null, response.ErrorMessage);
        }

        [TestMethod]
        public void ValidateRequest_AddEmployee_NameIsNullOrEmpty_ReturnErrorTrue() 
        {
            _addEmployeeRequest = new AddEmployeeRequest
            {
                Name = "",
                Position = "Full Stack Dev",
                Email = "Email",
                PhoneNumber = "09123456789",
                Address = "Address"
            };

            ValidatorResponse response = _validator.ValidateRequest(_addEmployeeRequest);

            Assert.IsTrue(response.HasError);
            Assert.AreEqual("Name can't be null or empty!", response.ErrorMessage);
        }

        [TestMethod]
        public void ValidateRequest_AddEmployee_NameWithInValidCharacters_ReturnErrorTrue()
        {
            _addEmployeeRequest = new AddEmployeeRequest
            {
                Name = "Jaymee!@#$%^&*()_-=+;:<>?/\\|",
                Position = "Full Stack Dev",
                Email = "Email",
                PhoneNumber = "09123456789",
                Address = "Address"
            };

            ValidatorResponse response = _validator.ValidateRequest(_addEmployeeRequest);

            Assert.IsTrue(response.HasError);
            Assert.AreEqual("Name contains invalid inputs.", response.ErrorMessage);
        }

        [TestMethod]
        public void ValidateRequest_AddEmployee_NameWithMoreThan100Characters_ReturnErrorTrue()
        {
            _addEmployeeRequest = new AddEmployeeRequest
            {
                Name = "pxdwmydoozxmllhzyizccqnvcpctkswjtviyofyihkqanvawhkvnixuncqkewjrnzxilhaadredglaxbnylkomlasdqweasdasdasprLuTQQVLXCIQbtCEQIZDNTjkeRXGQzrRSEvpbdHyshzmMyockWsHzczBNsgikpyhowDpjYdRiIVDuVBHYgNASEkhnNyeyRZQunFW",
                Position = "Full Stack Dev",
                Email = "Email",
                PhoneNumber = "09123456789",
                Address = "Address"
            };

            ValidatorResponse response = _validator.ValidateRequest(_addEmployeeRequest);

            Assert.IsTrue(response.HasError);
            Assert.AreEqual("Name contains invalid inputs.", response.ErrorMessage);
        }

        [TestMethod]
        public void ValidateRequest_EditEmployee_NameWithValidInput_ReturnErrorFalse()
        {
            _editEmployeeRequest = new EditEmployeeRequest
            {
                Name = "Jaymee",
                Position = "Full Stack Dev",
                Email = "Email",
                PhoneNumber = "09123456789",
                Address = "Address"
            };

            ValidatorResponse response = _validator.ValidateRequest(_editEmployeeRequest);

            Assert.IsFalse(response.HasError);
            Assert.AreEqual(null, response.ErrorMessage);
        }

        [TestMethod]
        public void ValidateRequest_EditEmployee_NameIsNullOrEmpty_ReturnErrorTrue()
        {
            _editEmployeeRequest = new EditEmployeeRequest
            {
                Name = "",
                Position = "Full Stack Dev",
                Email = "Email",
                PhoneNumber = "09123456789",
                Address = "Address"
            };

            ValidatorResponse response = _validator.ValidateRequest(_editEmployeeRequest);

            Assert.IsTrue(response.HasError);
            Assert.AreEqual("Name can't be null or empty!", response.ErrorMessage);
        }

        [TestMethod]
        public void ValidateRequest_EditEmployee_NameWithInValidCharacters_ReturnErrorTrue()
        {
            _editEmployeeRequest = new EditEmployeeRequest
            {
                Name = "Jaymee!@#$%^&*()_-=+;:<>?/\\|",
                Position = "Full Stack Dev",
                Email = "Email",
                PhoneNumber = "09123456789",
                Address = "Address"
            };

            ValidatorResponse response = _validator.ValidateRequest(_editEmployeeRequest);

            Assert.IsTrue(response.HasError);
            Assert.AreEqual("Name contains invalid inputs.", response.ErrorMessage);
        }

        [TestMethod]
        public void ValidateRequest_EditEmployee_NameWithMoreThan100Characters_ReturnErrorTrue()
        {
            _editEmployeeRequest = new EditEmployeeRequest
            {
                Name = "pxdwmydoozxmllhzyizccqnvcpctkswjtviyofyihkqanvawhkvnixuncqkewjrnzxilhaadredglaxbnylkomlasdqweasdasdasprLuTQQVLXCIQbtCEQIZDNTjkeRXGQzrRSEvpbdHyshzmMyockWsHzczBNsgikpyhowDpjYdRiIVDuVBHYgNASEkhnNyeyRZQunFW",
                Position = "Full Stack Dev",
                Email = "Email",
                PhoneNumber = "09123456789",
                Address = "Address"
            };

            ValidatorResponse response = _validator.ValidateRequest(_editEmployeeRequest);

            Assert.IsTrue(response.HasError);
            Assert.AreEqual("Name contains invalid inputs.", response.ErrorMessage);
        }
    }
}
