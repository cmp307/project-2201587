﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMP307Project
{
    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }

    // class definitions for handling API response
    // made using:
    // https://json2csharp.com/
    // https://fullduck.dev/how-to-turn-an-api-response-into-a-csharp-class/#get-raw-response
    public class Configuration
    {
        public List<Node> nodes { get; set; }
        public string @operator { get; set; }
    }

    public class CpeMatch
    {
        public bool vulnerable { get; set; }
        public string criteria { get; set; }
        public string matchCriteriaId { get; set; }
        public string versionEndIncluding { get; set; }
        public string versionEndExcluding { get; set; }
    }

    public class Cve
    {
        public string id { get; set; }
        public string sourceIdentifier { get; set; }
        public DateTime published { get; set; }
        public DateTime lastModified { get; set; }
        public string vulnStatus { get; set; }
        public List<object> cveTags { get; set; }
        public List<Description> descriptions { get; set; }
        public Metrics metrics { get; set; }
        public List<Weakness> weaknesses { get; set; }
        public List<Configuration> configurations { get; set; }
        public List<Reference> references { get; set; }
        public string cisaExploitAdd { get; set; }
        public string cisaActionDue { get; set; }
        public string cisaRequiredAction { get; set; }
        public string cisaVulnerabilityName { get; set; }
    }

    public class CvssData
    {
        public string version { get; set; }
        public string vectorString { get; set; }
        public double baseScore { get; set; }
        public string baseSeverity { get; set; }
        public string attackVector { get; set; }
        public string attackComplexity { get; set; }
        public string privilegesRequired { get; set; }
        public string userInteraction { get; set; }
        public string scope { get; set; }
        public string confidentialityImpact { get; set; }
        public string integrityImpact { get; set; }
        public string availabilityImpact { get; set; }
        public string accessVector { get; set; }
        public string accessComplexity { get; set; }
        public string authentication { get; set; }
    }

    public class CvssMetricV2
    {
        public string source { get; set; }
        public string type { get; set; }
        public CvssData cvssData { get; set; }
        public string baseSeverity { get; set; }
        public double exploitabilityScore { get; set; }
        public double impactScore { get; set; }
        public bool acInsufInfo { get; set; }
        public bool obtainAllPrivilege { get; set; }
        public bool obtainUserPrivilege { get; set; }
        public bool obtainOtherPrivilege { get; set; }
        public bool? userInteractionRequired { get; set; }
    }

    public class CvssMetricV30
    {
        public string source { get; set; }
        public string type { get; set; }
        public CvssData cvssData { get; set; }
        public double exploitabilityScore { get; set; }
        public double impactScore { get; set; }
    }

    public class CvssMetricV31
    {
        public string source { get; set; }
        public string type { get; set; }
        public CvssData cvssData { get; set; }
        public double exploitabilityScore { get; set; }
        public double impactScore { get; set; }
    }

    public class Description
    {
        public string lang { get; set; }
        public string value { get; set; }
    }

    public class Description2
    {
        public string lang { get; set; }
        public string value { get; set; }
    }

    public class Metrics
    {
        public List<CvssMetricV30> cvssMetricV30 { get; set; }
        public List<CvssMetricV2> cvssMetricV2 { get; set; }
        public List<CvssMetricV31> cvssMetricV31 { get; set; }
    }

    public class Node
    {
        public string @operator { get; set; }
        public bool negate { get; set; }
        public List<CpeMatch> cpeMatch { get; set; }
    }

    public class Reference
    {
        public string url { get; set; }
        public string source { get; set; }
        public List<string> tags { get; set; }
    }

    public class Root
    {
        public int resultsPerPage { get; set; }
        public int startIndex { get; set; }
        public int totalResults { get; set; }
        public string format { get; set; }
        public string version { get; set; }
        public DateTime timestamp { get; set; }
        public List<Vulnerability> vulnerabilities { get; set; }
    }

    public class Vulnerability
    {
        public Cve cve { get; set; }
    }

    public class Weakness
    {
        public string source { get; set; }
        public string type { get; set; }
        public List<Description> description { get; set; }
    }


}
