using NUnit.Framework;
using Resplan.Menghi.Project;
using Resplan.Sirri.Role;

namespace Resplan.Sirri.Test
{
    [TestFixture]
    public class TestRole
    {
        [Test]
        public void TestSpeechRole()
        {
            var role = new SpeechRole("without description");
            Assert.AreEqual(IRole.RoleType.Speech, role.Type);
            Assert.AreEqual("without description", role.Title);
            Assert.IsNull(role.Description);
            Assert.IsNull(role.Speaker);
            role.Speaker = new Speaker(15, "Luca", "Pasini");
            Assert.AreEqual(15, role.Speaker.SpeakerCode);
            var role2 = new SpeechRole("with description", "describe", 
                new Speaker(2, "Giacomo", "Sirri"));
            Assert.AreEqual("with description", role2.Title);
            Assert.AreEqual("describe", role2.Description);
            Assert.AreEqual("Sirri", role2.Speaker?.LastName);
            role2.Speaker = new Speaker(4, "Gabriele", "Menghi");
            Assert.AreEqual("Gabriele", role2.Speaker.FirstName);
        }

        [Test]
        public void TestSoundtrackRole()
        {
            IRole role = new SoundtrackRole("without description");
            Assert.AreEqual(IRole.RoleType.Soundtrack, role.Type);
            Assert.AreEqual("without description", role.Title);
            Assert.IsNull(role.Description);
            IRole role2 = new SoundtrackRole("with description", "try");
            Assert.AreEqual(IRole.RoleType.Soundtrack, role2.Type);
            Assert.AreEqual("with description", role2.Title);
            Assert.AreEqual("try", role2.Description);
        }

        [Test]
        public void TestEffectsRole()
        {
            IRole role = new EffectsRole("without description");
            Assert.AreEqual(IRole.RoleType.Effects, role.Type);
            Assert.AreEqual("without description", role.Title);
            Assert.IsNull(role.Description);
            IRole role2 = new EffectsRole("with description", "description");
            Assert.AreEqual(IRole.RoleType.Effects, role2.Type);
            Assert.AreEqual("with description", role2.Title);
            Assert.AreEqual("description", role2.Description);
        }
    }
}