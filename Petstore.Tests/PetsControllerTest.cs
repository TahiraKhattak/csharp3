// <copyright file="PetsControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace Petstore.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;
    using Petstore.Standard;
    using Petstore.Standard.Controllers;
    using Petstore.Standard.Exceptions;
    using Petstore.Standard.Http.Client;
    using Petstore.Standard.Http.Response;
    using Petstore.Standard.Utilities;

    /// <summary>
    /// PetsControllerTest.
    /// </summary>
    [TestFixture]
    public class PetsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private PetsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.PetsController;
        }

        /// <summary>
        /// Create a pet and key characteristics.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCreatePets()
        {
            // Parameters for the API call
            Standard.Models.Pet body = ApiHelper.JsonDeserialize<Standard.Models.Pet>("{\"id\":12345,\"name\":\"Indiana\",\"petType\":\"dog\"}");

            // Perform API call
            try
            {
                await this.controller.CreatePetsAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(201, HttpCallBack.Response.StatusCode, "Status should be 201");
        }

        /// <summary>
        /// List all pets.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListPets()
        {
            // Parameters for the API call
            int? limit = 10;

            // Perform API call
            List<Standard.Models.Pet> result = null;
            try
            {
                result = await this.controller.ListPetsAsync(limit);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("x-next", null);
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    HttpCallBack.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsProperSubsetOf(
                    "[{\"id\":12345,\"name\":\"Indiana\",\"petType\":\"dog\"},{\"id\":56789,\"name\":\"Shadow\",\"petType\":\"cat\"}]",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Info for a specific pet.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestShowPetById()
        {
            // Parameters for the API call
            string petId = "33918";

            // Perform API call
            Standard.Models.Pet result = null;
            try
            {
                result = await this.controller.ShowPetByIdAsync(petId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    HttpCallBack.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsProperSubsetOf(
                    "{\"id\":12345,\"name\":\"Cody\",\"petType\":\"dog\"}",
                    TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}