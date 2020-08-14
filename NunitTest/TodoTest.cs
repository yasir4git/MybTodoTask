/**
* M. Yasir Burhan
* 2020 08 14
* TodoTask for Karya Murni Publisher
*/
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MybTodoTask.NunitTest
{
    [TestFixture]
    public class TodoTest
    {
        private const string BASE_URL = "http://localhost:5000/api/todo";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetAllTodo()
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public void TestGetTodoById()
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("1", Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode == HttpStatusCode.OK && response != null);
        }

        [Test]
        public void TestGetTodoToday()
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("today", Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode == HttpStatusCode.OK && response != null);
        }

        [Test]
        public void TestGetTodoNext()
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("next", Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode == HttpStatusCode.OK && response != null);
        }

        [Test]
        public void TestGetTodoWeek()
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("week", Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode == HttpStatusCode.OK && response != null);
        }

        [Test]
        public void TestCreateTodo()
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(new
            {
                title = "test title 1",
                description = "test description 1",
                expired = DateTime.Now.Date,
                percentComplete = 0
            });
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode == HttpStatusCode.Created && response != null);
        }

        [Test]
        public void TestUpdateTodo()
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("5", Method.PUT);

            DateTime skrg = DateTime.Now.Date;
            skrg = skrg.AddDays(4);
            request.AddJsonBody(new
            {
                title = "test title 1 edit",
                description = "test description 1 edit",
                expired = skrg,
                percentComplete = 30
            });
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode == HttpStatusCode.Created && response != null);
        }

        [Test]
        public void TestUpdateTodoPercent()
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("5/setpros", Method.PUT);

            request.AddJsonBody(new
            {
                percentComplete = 84
            });
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode == HttpStatusCode.Created && response != null);
        }

        [Test]
        public void TestTodoMarkDone()
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("5/setdone", Method.PUT);

            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode == HttpStatusCode.Created && response != null);
        }

        [Test]
        public void TestDeleteTodo()
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest request = new RestRequest("6", Method.DELETE);

            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode == HttpStatusCode.OK && response != null);
        }
    }
}
