using System;
using Xunit;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.DAL.Entities;
using SocialNetwork;
using Moq;
using SocialNetwork.BLL.Exceptions;

namespace SocialNetwork.Tests
{
    
    public class UserRepositoryTests
    {
        static string email = "d.sankeev@gmail.com";

        [Fact]
        public void FindByEmailMustReturnCoorectValue()
        {
            var userEntity = new UserEntity
            {
                firstname = "Dima",
                lastname = "Sankeev",
                email = "d.sankeev@gmail.com",  
                password = "qwerty1234!",
                id = 1,
                favorite_book = "Война и Мир",
                favorite_movie = "",
                photo = ""
            };

            Mock<IUserRepository> mockUserRepFindByEmail = new Mock<IUserRepository>();
            mockUserRepFindByEmail.Setup(x => x.FindByEmail(email)).Returns(userEntity);
            Assert.Equal(email, userEntity.email);
        }

        [Fact]
        public void FindByEmailMustThrowException()
        {
            Mock<IUserRepository> mockUserRepFindByEmail = new Mock<IUserRepository>();
            mockUserRepFindByEmail.Setup(x => x.FindByEmail(email)).Throws<UserNotFoundException>();
            Assert.Throws<UserNotFoundException>(() => mockUserRepFindByEmail.Object.FindByEmail(email));
        }

    }
}
