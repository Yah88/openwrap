using NUnit.Framework;
using OpenWrap.Testing;

namespace Tests.preloading.locating.project
{
    class package_with_semver_found : contexts.preloader
    {
        public package_with_semver_found()
        {

            given_project_directory();
            given_project_package("bootstrap", "1.0.0+build.0");
            given_project_package("bootstrap", "1.0.0+build.1");
            given_project_descriptor("project.wrapdesc");

            when_locating_package("bootstrap");
        }
        [Test]
        public void package_path_is_found()
        {
            package_directories.ShouldHaveOne(
                project_directory.GetDirectory("wraps")
                    .GetDirectory("_cache")
                    .GetDirectory("bootstrap-1.0.0+build.1").Path.FullPath);

        }
    }
}