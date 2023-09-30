namespace CountryGWP.Test.Tests
{
    public class GWPCountryRepositoryTest : BaseTest
    {
        [Test]
        public async Task CalculateAverageGWPAsync_EmptyCountryField_ReturnsBadRequest()
        {
            object result;

            try
            {
                result = await _GWPRepository.CalculateAverageGwpAsync("", new List<string> { "transport" });
            }
            catch (ArgumentNullException ex)
            {
                result = ex;
            }
            catch (Exception ex)
            {
                result = ex;
            }

            // Assert
            Assert.IsNotNull(result);
            Assert.True(result is ArgumentNullException);
        }

        [Test]
        public async Task CalculateAverageGWPAsync_EmptyLobField_ReturnsBadRequest()
        {
            object result;

            try
            {
                result = await _GWPRepository.CalculateAverageGwpAsync("ae", null);
            }
            catch (ArgumentNullException ex)
            {
                result = ex;
            }
            catch (Exception ex)
            {
                result = ex;
            }

            // Assert
            Assert.IsNotNull(result);
            Assert.True(result is ArgumentNullException);
        }

        [Test]
        public async Task CalculateAverageGWPAsync_ShouldReturnZeroForNonExistingCountryAndLOB()
        {
            // Act
            var result = await _GWPRepository.CalculateAverageGwpAsync("nonexistent", new List<string> { "nonexistent" });

            // Assert
            Assert.True(0 == result.Values.FirstOrDefault()); // No data, so the result should be 0
        }
    }
}
