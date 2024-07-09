using Google.Cloud.Firestore;
using System.IO;
using System;

internal static class FirestoreHelper
{
    static readonly string fireconfig = @"{
      ""type"": ""service_account"",
      ""project_id"": ""worktimetracker-4a293"",
      ""private_key_id"": ""2d2305e7b8439e715a85f746a9aa201181b1b4f1"",
      ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCV01NSaRREEMFg\niPySi71W/lgIv3/LikkcBf23Gf7kV/prlpKlgSTbg21V1+ih4idX29zzuqm8Xj17\nL3Uo9BtwBBpzao6CHCZzMrRs8n+rDsBmfyeu6kSu6wfP1KHW//9ES+jzzEoqnkr+\nKx0MKOWWyJ+EUu58QtHeuUCVOJElU8ypLUQloGo2X1H5CNYYs0pH+NVhZGnlfI9h\nWVfzf4M5AhDkHfid6zfbHvWl2E9IvW2Qy96/BBY7aYOngZCZQe/1UdRkiS+C1NlN\nOYe8FwuCf8pU/lFR/KX8c0t//eUmX8sp4WaOVZ/0fZgPjW/aHb3G/y6zMqmm7Nw+\nnL10L0iHAgMBAAECggEADqRPrkFqo5mSQbbhcrOJVhPBKAm0RCtIKHRFbpFxzCr0\n5B1w82UC5G5G+cQB42Al7CYmb63m90EBInq+07kXaAOz+gzdzxqlKfjjPQpt2O+2\nHyN/Y06tq6fNuaJ+tnOKJMiDrt+2F815vWEak5z44vAe9rWMF5oIHItfeQsa1C+N\nSeHwisdr947TIXjSvAoqOEXTkMCoqs0yg8d1OgfHpLdvZgBLztMz5NDq/p6bu7k3\ngMj6r87m/eh71X3lmdjuDRIXfhMQLa/B5HmfFJX/62aWVWlcK9lJhWf+za1y2RIm\ng3tNaC9VEpwzBrZkPbuGD1ZhQ4nVZCqZ02ivRFsegQKBgQDSEPZsEeFDj+PPuI61\n9dMoQM4ng1YM2ALy4FVDvmheN+kgp6O/r+qJPz+4428ntktujLX27jYA6YtFYiyp\nCOzUNTxp2RYjDZUPCW9mYZ9L6JuEtABak/9jGlnIsv6U8ldc9zMvxOctRYzEWH5u\nNt0MOPW5cNTzoWWRzEMUrzalYQKBgQC2ljhK7LW9x+tz9QOQUDFzLZBD0J3vco2t\naZ7pl55JJQ4CKmw9fq7z8bk+9oWgWcgtdka+j5bI8W0VLohKP608IG8x4tSDnwIJ\n45zLYZDo7aZ8140aUjkOYxdzYpW3R9hgHcURhyFVevRVE94Y5VITbB/Dr3FQGI4P\nPHL5SEzO5wKBgQCm9URl8HARurNdzVnf1VnWjGtNjF1AKA9v6kzaYuOgvt9TTOog\n2DiYjOSglmMqNQEPBFc7w2i4oOZIZxcH4kgZAZbaqeemRI1MPjuEK+Ln+iBhAI+n\nbil1IuRpV5pv140IHpFYTi9PFBAlnhAemQxnQn5KvRsD6CtKDgbi0b+lAQKBgCia\nc15GEYxonvWkcOxwyO5iHYjXJagQA22i5VHxA6Qkd18H7BYoy+M3yAg2bjTggmGJ\nweWyrMd22NkzBd/tFSsf01p2pOe4Po3QbhfUVJNX9gQhMyG9Uy7d3mMsczrU4UtO\nk3p4YHNP6nHY/zTuGjhzfQTZSQuUylKdELxa1anVAoGAbJOP1YWCufkwPcLPhen5\nLWxtRcPY3c/5ABxe/VrquepaU9CApiig7zD+4nz8JcdgzIFuJ0EO9SckpOjNihQG\nIhvKzlaBrK1mAkFmoNvqaa0EcuL+1mlsoKUJghAGRvpYSCYRUdJX9he+7lNorYJ2\npqnyz/3+wYacE56nvo3iFsE=\n-----END PRIVATE KEY-----\n"",
      ""client_email"": ""firebase-adminsdk-mbr2o@worktimetracker-4a293.iam.gserviceaccount.com"",
      ""client_id"": ""114689081109621564769"",
      ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
      ""token_uri"": ""https://oauth2.googleapis.com/token"",
      ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
      ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-mbr2o%40worktimetracker-4a293.iam.gserviceaccount.com"",
      ""universe_domain"": ""googleapis.com""
    }";

    static string filepath = "";

    private static FirestoreDb Database { get; set; }

    public static void SetEnvironmentVariable()
    {
        filepath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + ".json";
        File.WriteAllText(filepath, fireconfig);
        File.SetAttributes(filepath, FileAttributes.Hidden);
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
        Database = FirestoreDb.Create("worktimetracker - 4a293");
        File.Delete(filepath);
    }
}
