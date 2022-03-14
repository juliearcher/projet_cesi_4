package utils;

public class SetCertificatePath {
	private static Boolean done = false;
	public static void Execute()	{
		if (done == false) {
			String certificatesTrustStorePath = "C:\\Program Files\\Java\\jre1.8.0_201\\lib\\security\\cacerts";
			System.setProperty("javax.net.ssl.trustStore", certificatesTrustStorePath);
			done = true;
		}
	}
}
