using request_response.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.Repositories;
using System.Xml.Linq;

namespace request_response.Test
{
    [NonParallelizable]
    [TestFixture]
    public class CoreTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Order(1)]
        [NonParallelizable]
        [Test]
        public void CreateStudent()
        {
        }

        [Order(2)]
        [NonParallelizable]
        [Test]
        public void GetAlStudents()
        {
        }

        [Order(3)]
        [NonParallelizable]
        [Test]
        public void GetStudentByFirstName()
        {
        }

        [Order(4)]
        [NonParallelizable]
        [Test]
        public void UpdateStudent()
        {
        }

        [Order(5)]
        [NonParallelizable]
        [Test]
        public void DeleteStudent()
        {
        }

        [Order(6)]
        [NonParallelizable]
        [Test]
        public void CreateLanguage()
        {
        }

        [Order(7)]
        [NonParallelizable]
        [Test]
        public void GetAllLanguages()
        {
        }

        [Order(8)]
        [NonParallelizable]
        [Test]
        public void GetLanguageByName()
        {
        }

        [Order(9)]
        [NonParallelizable]
        [Test]
        public void UpdateLanguage()
        {
        }

        [Order(10)]
        [NonParallelizable]
        [Test]
        public void DeleteLanguage()
        {
        }
    }
}