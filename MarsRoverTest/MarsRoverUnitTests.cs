using Moq;
using Mars.Vehicle.Enums;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;
using Mars.Vehicle.Core;

namespace MarsRoverTest
{
    [ExcludeFromCodeCoverage]
    public class MarsRoverUnitTests
    {
        [Fact]
        public void When_Add_Two_Things_To_Same_Location_Throws_ArgumentException()
        {
            //Arrange
            IPlateu _plateu = new Plateu(5, 5);

            //Act
            _plateu.AddVehicle(new Mock<IVehicle>().Object, 1, 1);
            void act() => _plateu.AddVehicle(new Mock<IVehicle>().Object, 1, 1);

            //Assert
            var exception = Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void When_Add_Thing_To_Outer_Place_Throws_IndexOutOfRangeException()
        {
            //Arrange
            IPlateu _plateu = new Plateu(5, 5);

            //Act
            void act() => _plateu.AddVehicle(new Mock<IVehicle>().Object, 6, 1);

            //Assert
            var exception = Assert.Throws<IndexOutOfRangeException>(act);
            Assert.Equal("You can't add anything to outer space", exception.Message);
        }

        [Fact]
        public void When_Add_Thing_IsAvailable_True()
        {
            //Arrange
            IPlateu _plateu = new Plateu(5, 5);

            //Act
            _plateu.AddVehicle(new Mock<IVehicle>().Object, 0, 1);
            _plateu.AddVehicle(new Mock<IVehicle>().Object, 2, 1);
            bool _isAvalable = _plateu.IsAvailable(1, 1);

            //Assert
            Assert.True(_isAvalable);
        }

        [Fact]
        public void When_Add_Thing_IsAvailable_False()
        {
            //Arrange
            IPlateu _plateu = new Plateu(5, 5);

            //Act
            _plateu.AddVehicle(new Mock<IVehicle>().Object, 0, 1);
            _plateu.AddVehicle(new Mock<IVehicle>().Object, 2, 1);
            bool _isAvalable = _plateu.IsAvailable(2, 1);

            //Assert
            Assert.False(_isAvalable);
        }

        [Fact]
        public void When_Add_Thing_IsAvailable_Outer_Space_False()
        {
            //Arrange
            IPlateu _plateu = new Plateu(5, 5);

            //Act
            _plateu.AddVehicle(new Mock<IVehicle>().Object, 0, 1);
            _plateu.AddVehicle(new Mock<IVehicle>().Object, 2, 1);
            bool _isAvalable = _plateu.IsAvailable(6, 1);

            //Assert
            Assert.False(_isAvalable);
        }

        [Fact]
        public void When_Vehicle_Landed_Success()
        {
            //Arrange
            IPlateu _plateu = new Plateu(5, 5);

            //Act
            IVehicle _vehicle = new NasaRover(_plateu, 1, 1, Directions.East);

            //Assert
            Assert.False(_plateu.IsAvailable(1, 1));
        }

        [Fact]
        public void When_Vehicle_Landed_Fail_Throws_ArgumentException()
        {
            //Arrange
            IPlateu _plateu = new Plateu(5, 5);

            //Act
            IVehicle _vehicle = new NasaRover(_plateu, 1, 1, Directions.East);
            void act() => new NasaRover(_plateu, 1, 1, Directions.East);

            //Assert
            var exception = Assert.Throws<ArgumentException>(act);
        }


        [Fact]
        public void When_Vehicle_Move_Success()
        {
            //Arrange
            IPlateu _plateu = new Plateu(5, 5);

            //Act
            IVehicle _vehicle = new NasaRover(_plateu, 1, 1, Directions.North);
            _vehicle.MoveForwards();

            //Assert
            Assert.False(_plateu.IsAvailable(1, 2));
            Assert.True(_plateu.IsAvailable(1, 1));
        }

        [Fact]
        public void When_Vehicle_Move_Fail()
        {
            //Arrange
            IPlateu _plateu = new Plateu(5, 5);

            //Act
            IVehicle _vehicle = new NasaRover(_plateu, 1, 1, Directions.North);
            IVehicle _vehicle2 = new NasaRover(_plateu, 1, 2, Directions.North);
            _vehicle.MoveForwards();

            //Assert
            Assert.False(_plateu.IsAvailable(1, 1));
            Assert.False(_plateu.IsAvailable(1, 2));
        }


        [Fact]
        public void When_Vehicle_TurnLeft_Success()
        {
            //Arrange
            IPlateu _plateu = new Plateu(5, 5);

            //Act
            IVehicle _vehicle = new NasaRover(_plateu, 1, 1, Directions.North);
            _vehicle.TurnLeft().MoveForwards();

            //Assert
            Assert.False(_plateu.IsAvailable(0, 1));
            Assert.True(_plateu.IsAvailable(1, 1));
        }

        [Fact]
        public void When_Vehicle_TurnRight_Success()
        {
            //Arrange
            IPlateu _plateu = new Plateu(5, 5);

            //Act
            IVehicle _vehicle = new NasaRover(_plateu, 1, 1, Directions.North);
            _vehicle.TurnRight().MoveForwards();

            //Assert
            Assert.False(_plateu.IsAvailable(2, 1));
            Assert.True(_plateu.IsAvailable(1, 1));
            Assert.Equal(2, ((Rover)_vehicle).X);
            Assert.Equal(1, ((Rover)_vehicle).Y);
            Assert.Equal(Directions.East, ((Rover)_vehicle).Direction);
        }

        [Fact]
        public void When_Expected_Output_Same()
        {
            //Test Input:
            //5 5
            //1 2 N
            //LMLMLMLMM
            //3 3 E
            //MMRMMRMRRM

            //Expected Output:
            //1 3 N
            //5 1 E

            //Arrange
            IPlateu _plateu = new Plateu(5, 5);

            //Act
            IVehicle _vehicle = new NasaRover(_plateu, 1, 2, Directions.North)
                .TurnLeft()
                .MoveForwards()
                .TurnLeft()
                .MoveForwards()
                .TurnLeft()
                .MoveForwards()
                .TurnLeft()
                .MoveForwards()
                .MoveForwards();

            //Act
            IVehicle _vehicle2 = new NasaRover(_plateu, 3, 3, Directions.East)
                .MoveForwards()
                .MoveForwards()
                .TurnRight()
                .MoveForwards()
                .MoveForwards()
                .TurnRight()
                .MoveForwards()
                .TurnRight()
                .TurnRight()
                .MoveForwards();

            //Assert
            Assert.False(_plateu.IsAvailable(1, 3));
            Assert.False(_plateu.IsAvailable(5, 1));
        }
    }
}
