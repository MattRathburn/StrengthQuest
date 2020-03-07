using System;
using Xunit;
using Extensions;

namespace StrengthQuest.Test
{
    public class MaxLiftCalculationsTests
    {
        [Fact]
        public void OneRepMax_500_Success()
        {
            // Arrange
            var weight = 500;
            var reps = 2;

            // Act
            var act = MaxLiftCalculations.OneRepMax(weight, reps);

            // Assert
            Assert.Equal(526, act);
        }

        [Fact]
        public void OneRepMax_200_Success()
        {
            // Arrange
            var weight = 200;
            var reps = 1;

            // Act
            var act = MaxLiftCalculations.OneRepMax(weight, reps);

            // Assert
            Assert.Equal(200, act);
        }

        [Fact]
        public void OneRepMax_NegativeWeight_Success()
        {
            // Arrange
            var weight = -100;
            var reps = 1;

            // Act
            var act = MaxLiftCalculations.OneRepMax(weight, reps);

            // Assert
            Assert.Equal(0.0, act);
        }

        [Fact]
        public void OneRepMax_NegativeReps_Success()
        {
            // Arrange
            var weight = 200;
            var reps = -1;

            // Act
            var act = MaxLiftCalculations.OneRepMax(weight, reps);

            // Assert
            Assert.Equal(187, act);
        }

        [Fact]
        public void OneRepMax_PositiveWeight_Success()
        {
            // Arrange
            var weight = 200;
            var reps = 3;

            // Act
            var act = MaxLiftCalculations.OneRepMax(weight, reps);

            // Assert
            Assert.Equal(218, act);
        }
    }
}
