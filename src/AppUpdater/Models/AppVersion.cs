using System.Text.RegularExpressions;

namespace AppUpdater.Models;

/// <summary>
    /// Provides version objects to enforce conformance to the Semantic Versioning 2.0 spec. The spec can be read at http://semver.org/
    /// </summary>
    public class AppVersion : IComparable<AppVersion>
    {
        private static readonly Regex VersionRegex = new Regex(@"^([\d.]+)(-([0-9A-Za-z\-.]+))?(\+([0-9A-Za-z\-.]+))?$");
        private static readonly Regex BuildRegex = new Regex(@"^[0-9A-Za-z\-.]+$");
        private static readonly Regex PreReleaseRegex = new Regex(@"^[0-9A-Za-z\-]+$");

        /// <summary>
        /// The major number of the version, incremented when making breaking changes.
        /// </summary>
        public int Major { get; }

        /// <summary>
        /// The minor number of the version, incremented when adding new functionality in a backwards-compatible manner.
        /// </summary>
        public int Minor { get; }

        /// <summary>
        /// The patch number of the version, incremented when making backwards-compatible bug fixes.
        /// </summary>
        public int Patch { get; }

        /// <summary>
        /// Build information relevant to the version. Does not contribute to sorting.
        /// </summary>
        public string Build { get; }

        /// <summary>
        /// Pre-release information segments.
        /// </summary>
        public List<string> PreRelease { get; }

        /// <summary>
        /// Indicates whether the version is a pre-release.
        /// </summary>
        public bool IsPreRelease => PreRelease.Count > 0;

        /// <summary>
        /// Creates a new instance of <see cref="AppVersion"/>.
        /// </summary>
        public AppVersion(int major, int minor, int patch, List<string> preRelease = null, string build = "")
        {
            Major = major;
            Minor = minor;
            Patch = patch;
            PreRelease = preRelease;
            Build = build;

            foreach (var segment in PreRelease)
            {
                if (string.IsNullOrWhiteSpace(segment))
                    throw new ArgumentException("Pre-release segments must not be empty");

                if (!PreReleaseRegex.IsMatch(segment))
                    throw new FormatException("Pre-release segments must only contain [0-9A-Za-z-]");
            }

            if (!string.IsNullOrEmpty(Build) && !BuildRegex.IsMatch(Build))
                throw new FormatException("Build must only contain [0-9A-Za-z-.]");

            if (Major < 0 || Minor < 0 || Patch < 0)
                throw new ArgumentException("Version numbers must be greater than or equal to 0");
        }

        public int CompareTo(AppVersion? other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            // Implement comparison logic here
            throw new NotImplementedException();
        }

        // Implement other methods and operators as needed

        public override string ToString()
        {
            // Implement ToString() method
            throw new NotImplementedException();
        }

        public static AppVersion Parse(string versionString)
        {
            if (string.IsNullOrWhiteSpace(versionString))
                throw new FormatException("Cannot parse empty string into version");

            if (!VersionRegex.IsMatch(versionString))
                throw new FormatException("Not a properly formatted version string");

            // Implement parsing logic here
            throw new NotImplementedException();
        }

        // Implement other static methods and fields as needed
    }