// <copyright file="PetsController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace Petstore.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using Petstore.Standard;
    using Petstore.Standard.Authentication;
    using Petstore.Standard.Exceptions;
    using Petstore.Standard.Http.Client;
    using Petstore.Standard.Utilities;
    using System.Net.Http;

    /// <summary>
    /// PetsController.
    /// </summary>
    public class PetsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PetsController"/> class.
        /// </summary>
        internal PetsController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Create a pet and key characteristics.
        /// </summary>
        /// <param name="body">Required parameter: A single Pet object used to create a new Pet.</param>
        public void CreatePets(
                Models.Pet body)
            => CoreHelper.RunVoidTask(CreatePetsAsync(body));

        /// <summary>
        /// Create a pet and key characteristics.
        /// </summary>
        /// <param name="body">Required parameter: A single Pet object used to create a new Pet.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task CreatePetsAsync(
                Models.Pet body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/pets")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("0", CreateErrorCase("unexpected error", (_reason, _context) => new ErrorException(_reason, _context))))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// List all pets.
        /// </summary>
        /// <param name="limit">Optional parameter: How many items to return at one time (max 100).</param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        public List<Models.Pet> ListPets(
                int? limit = null)
            => CoreHelper.RunTask(ListPetsAsync(limit));

        /// <summary>
        /// List all pets.
        /// </summary>
        /// <param name="limit">Optional parameter: How many items to return at one time (max 100).</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        public async Task<List<Models.Pet>> ListPetsAsync(
                int? limit = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<Models.Pet>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/pets")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("limit", limit))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("0", CreateErrorCase("unexpected error", (_reason, _context) => new ErrorException(_reason, _context))))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Info for a specific pet.
        /// </summary>
        /// <param name="petId">Required parameter: The id of the pet to retrieve.</param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public Models.Pet ShowPetById(
                string petId)
            => CoreHelper.RunTask(ShowPetByIdAsync(petId));

        /// <summary>
        /// Info for a specific pet.
        /// </summary>
        /// <param name="petId">Required parameter: The id of the pet to retrieve.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public async Task<Models.Pet> ShowPetByIdAsync(
                string petId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.Pet>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/pets/{petId}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("petId", petId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("0", CreateErrorCase("unexpected error", (_reason, _context) => new ErrorException(_reason, _context))))
              .ExecuteAsync(cancellationToken);
    }
}