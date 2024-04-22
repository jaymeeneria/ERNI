using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using TechExam3.Controllers;
using TechExam3.Interface;
using TechExam3.Model;
using TechExam3.Valicator;

namespace UnitTesting.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private Mock<IEmployeeRepository> _mockRepository;
        private Mock<IEmployeeValidator> _mockValidator;
        private EmployeeValidator _validator;
        private EmployeeController _employeeController;
        private EmployeeModel _employeeModel;

        [TestInitialize]
        public void Setup()
        {
            _mockValidator = new Mock<IEmployeeValidator>();
            _mockRepository = new Mock<IEmployeeRepository>();
            _validator = new EmployeeValidator();
        }

        private AddEmployeeRequest CreateEmployeeSetupData() 
        {
            AddEmployeeRequest employeeRequest = new AddEmployeeRequest
            {
                Name = "Jaymee",
                Position = "Full Stack Dev",
                Email = "Email",
                PhoneNumber = "09123456789",
                Address = "Address"
            };

            _mockRepository.Setup(x => x.AddEmployee(employeeRequest))
                .Returns(new EmployeeModel
                {
                    Id = 9999,
                    Address = "Quezon City, Philippines",
                    Email = "employee1@gmail.com",
                    Name = "Jaymee",
                    PhoneNumber = "09123456789",
                    Position = "Full Stack Dev",
                    IsActive = true
                });

            return employeeRequest;
        }

        private EditEmployeeRequest EditEmployeeSetupData()
        {
            _employeeModel = new EmployeeModel
            {
                Id = 123,
                Address = "Quezon City, Philippines",
                Email = "email@email.com",
                Name = "Jaymee",
                PhoneNumber = "09123456999",
                Position = "Full Stack Dev",
                IsActive = true
            };

            EditEmployeeRequest employeeRequest = new EditEmployeeRequest
            {
                Id = 123,
                Name = "Jaymee",
                Position = "Full Stack Dev",
                Email = "Email",
                PhoneNumber = "09123456789",
                Address = "Address"
            };

            _mockRepository.Setup(x => x.EditEmployee(employeeRequest))
                .Returns(_employeeModel);

            return employeeRequest;
        }

        [TestMethod]
        public void GetEmployeeList_ReturnOK()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetEmployee(1))
                .Returns(new List<EmployeeModel>
                {
                    new EmployeeModel
                    {
                        Id =1
                    }
                });

            _employeeController = new EmployeeController(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = _employeeController.GetEmployeeList(1);
            var obj = result as ObjectResult;

            //Assert
            Assert.AreEqual(200, obj.StatusCode);

        }

        [TestMethod]
        public void GetEmployeeList_ThrowException()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetEmployee(1)).Throws(new Exception());

            _employeeController = new EmployeeController(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = _employeeController.GetEmployeeList(1);

            var obj = result as IStatusCodeActionResult;
             
            //Assert
            Assert.AreEqual(500, obj.StatusCode);
        }

        [TestMethod]
        public void CreateEmployee_ReturnOK()
        {
            // Arrange
            AddEmployeeRequest employeeRequest = CreateEmployeeSetupData();
            
            _mockValidator.Setup(x => x.ValidateRequest(employeeRequest))
                .Returns(new ValidatorResponse { HasError = false });

            _employeeController = new EmployeeController(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = _employeeController.CreateEmployee(employeeRequest);
            var obj = result as ObjectResult;

            //Assert
            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public void CreateEmployee_ReturnBadRequest()
        {
            // Arrange
            AddEmployeeRequest employeeRequest = CreateEmployeeSetupData();

            _mockValidator.Setup(x => x.ValidateRequest(employeeRequest))
                .Returns(new ValidatorResponse { HasError = true });

            _employeeController = new EmployeeController(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = _employeeController.CreateEmployee(employeeRequest);
            var obj = result as ObjectResult;

            //Assert
            Assert.AreEqual(400, obj.StatusCode);
        }

        [TestMethod]
        public void EditEmployee_ReturnOK()
        {
            // Arrange
            EditEmployeeRequest employeeRequest = EditEmployeeSetupData();

            _mockValidator.Setup(x => x.ValidateRequest(employeeRequest))
                .Returns(new ValidatorResponse { HasError = false });

            _mockRepository.Setup(x => x.GetEmployee(123))
              .Returns(new List<EmployeeModel> { _employeeModel });

            _employeeController = new EmployeeController(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = _employeeController.EditEmployee(employeeRequest);
            var obj = result.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public void EditEmployee_ReturnBadRequest()
        {
            // Arrange
            EditEmployeeRequest employeeRequest = EditEmployeeSetupData();

            _mockValidator.Setup(x => x.ValidateRequest(employeeRequest))
                .Returns(new ValidatorResponse { HasError = true });

            _mockRepository.Setup(x => x.GetEmployee(123))
              .Returns(new List<EmployeeModel> { _employeeModel });

            _employeeController = new EmployeeController(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = _employeeController.EditEmployee(employeeRequest);
            var obj = result.Result as ObjectResult;

            //Assert
            Assert.AreEqual(400, obj.StatusCode);
        }

        [TestMethod]
        public void EditEmployee_ReturnNotFound()
        {
            // Arrange
            EditEmployeeRequest employeeRequest = EditEmployeeSetupData();
            List<EmployeeModel> employeeModelList = null;

            _mockValidator.Setup(x => x.ValidateRequest(employeeRequest))
                .Returns(new ValidatorResponse { HasError = false });

            _mockRepository.Setup(x => x.GetEmployee(123))
              .Returns(employeeModelList);

            _employeeController = new EmployeeController(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = _employeeController.EditEmployee(employeeRequest);
            var obj = result.Result as IStatusCodeActionResult;

            //Assert
            Assert.AreEqual(404, obj.StatusCode);
        }

        [TestMethod]
        public void CreateEmployee_ThrowException()
        {
            // Arrange
            AddEmployeeRequest employeeRequest = CreateEmployeeSetupData();

            _mockRepository.Setup(x => x.AddEmployee(employeeRequest)).Throws(new Exception());

            _mockValidator.Setup(x => x.ValidateRequest(employeeRequest))
                .Returns(new ValidatorResponse { HasError = false });

            _employeeController = new EmployeeController(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = _employeeController.CreateEmployee(employeeRequest);
            var obj = result as IStatusCodeActionResult; ;

            //Assert
            Assert.AreEqual(500, obj.StatusCode);
        }

        [TestMethod]
        public void DeleteEmployee_ReturnOK()
        {
            // Arrange
            _mockRepository.Setup(x => x.DeleteEmployee(1))
                .Returns(
                    new EmployeeModel
                    {
                        Id =1
                    }
                );

            _employeeController = new EmployeeController(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = _employeeController.DeleteEmployee(1);
            var obj = result as ObjectResult;

            //Assert
            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public void DeleteEmployee_ThrowException()
        {
            // Arrange
            _mockRepository.Setup(x => x.DeleteEmployee(1)).Throws(new Exception());

            _employeeController = new EmployeeController(_mockRepository.Object, _mockValidator.Object);

            //Act
            var result = _employeeController.DeleteEmployee(1);

            var obj = result as IStatusCodeActionResult;

            //Assert
            Assert.AreEqual(500, obj.StatusCode);
        }

        [TestMethod]
        public void CreateEmployee_ValidatorIsNotMocked_NameIsNullOrEmpty_ReturnBadRequest()
        {
            // Arrange
            AddEmployeeRequest employeeRequest = new AddEmployeeRequest
            {
                Name = "",
                Position = "Full Stack Dev",
                Email = "Email",
                PhoneNumber = "09123456789",
                Address = "Address"
            };

            _employeeController = new EmployeeController(_mockRepository.Object, _validator);

            //Act
            var result = _employeeController.CreateEmployee(employeeRequest);
            var obj = result as ObjectResult;

            //Assert
            Assert.AreEqual(400, obj.StatusCode);
        }

        [TestMethod]
        public void CreateEmployee_ValidatorIsNotMocked_NameHasSpecialCharacters_ReturnBadRequest()
        {
            // Arrange
            AddEmployeeRequest employeeRequest = new AddEmployeeRequest
            {
                Name = "Jaymee !@#$%^&*()_-=+;:<>?/\\|",
                Position = "Full Stack Dev",
                Email = "Email",
                PhoneNumber = "09123456789",
                Address = "Address"
            };

            _employeeController = new EmployeeController(_mockRepository.Object, _validator);

            //Act
            var result = _employeeController.CreateEmployee(employeeRequest);
            var obj = result as ObjectResult;

            //Assert
            Assert.AreEqual(400, obj.StatusCode);
        }

        [TestMethod]
        public void CreateEmployee_ValidatorIsNotMocked_NameMoreThan100Characters_ReturnBadRequest()
        {
            // Arrange
            AddEmployeeRequest employeeRequest = new AddEmployeeRequest
            {
                Name = "Jaymee jrnzxilhaadredglaxbnylkomlasdqweasdasdasprLuTQQVLXCIQbtCEQIZDNTjkeRXGQzrRSEvpbdHyshzmMyockWsHzczBNsg",
                Position = "Full Stack Dev",
                Email = "Email",
                PhoneNumber = "09123456789",
                Address = "Address"
            };

            _employeeController = new EmployeeController(_mockRepository.Object, _validator);

            //Act
            var result = _employeeController.CreateEmployee(employeeRequest);
            var obj = result as ObjectResult;

            //Assert
            Assert.AreEqual(400, obj.StatusCode);
        }
    }
}