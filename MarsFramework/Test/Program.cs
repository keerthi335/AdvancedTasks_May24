using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test]
            public void ShareSkillTest()
            {
                ShareSkill shareSkill = new ShareSkill();
                shareSkill.EnterShareSkill();

                bool Result = shareSkill.ValidateShareSkill(Global.GlobalDefinitions.driver);
                Assert.IsTrue(Result);
            }

            [Test]
            public void EditListingTest()
            {
                ManageListings manageListings = new ManageListings();
                manageListings.EditListings();

                bool EditResult = manageListings.ValidateEdit(Global.GlobalDefinitions.driver);
                Assert.IsTrue(EditResult);
            }

            [Test]
            public void DeleteListingTest()
            {
                ManageListings manageListings = new ManageListings();
                manageListings.DeleteListings();

                bool DelResult = manageListings.ValidateDelete(Global.GlobalDefinitions.driver);
                Assert.IsTrue(DelResult);
            }

            [Test]
            public void ChangePassword()
            {
                Profile profile = new Profile();
                profile.ChangePassword();

                bool PwdChgResult = profile.ValidateChangePassword(Global.GlobalDefinitions.driver);
                Assert.IsTrue(PwdChgResult);
            }


        }
    }
}