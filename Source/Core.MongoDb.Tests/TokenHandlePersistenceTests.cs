﻿using Thinktecture.IdentityServer.Core.Models;
using Xunit;

namespace Core.MongoDb.Tests
{
    public class TokenHandlePersistenceTests : PersistenceTest, IUseFixture<RequireAdminService>
    {
        private Token _actual;
        private Token _expected;

        [Fact]
        public void NotNull()
        {
            Assert.NotNull(_actual);
        }

        [Fact]
        public void CheckAudience()
        {
            Assert.Equal(_expected.Audience, _actual.Audience);
        }
        [Fact]
        public void CheckClaims()
        {
            CommonVerifications.VerifyClaimset(_expected.Claims, _actual.Claims);
        }

        [Fact]
        public void CheckClient()
        {
            Assert.NotNull(_actual.Client);
            Assert.Equal(_expected.ClientId, _actual.ClientId);
        }

        [Fact]
        public void CheckCreationTime()
        {
            Assert.Equal(_expected.CreationTime, _actual.CreationTime);
        }

        [Fact]
        public void CheckIssuer()
        {
            Assert.Equal(_expected.Issuer, _actual.Issuer);
        }

        [Fact]
        public void CheckLifetime()
        {
            Assert.Equal(_expected.Lifetime, _actual.Lifetime);
        }


        [Fact]
        public void CheckSubjectId()
        {
            Assert.Equal(_expected.SubjectId, _actual.SubjectId);
        }

        [Fact]
        public void CheckScopes()
        {
            Assert.Equal(_expected.Scopes, _actual.Scopes);
        }

        [Fact]
        public void CheckType()
        {
            Assert.Equal(_expected.Type, _actual.Type);
        }

        protected override void Initialize()
        {
            var store = Factory.TokenHandleStore.TypeFactory();
            var key = GetType().Name;
            _expected = TestData.Token();
            store.StoreAsync(key, _expected);
            _actual = store.GetAsync(key).Result;
        }
    }
}