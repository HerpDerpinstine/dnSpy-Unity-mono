using System;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

[StrongNameIdentityPermission (SecurityAction.InheritanceDemand, PublicKey="0024000004800000940000000602000000240000525341310004000011000000db294bcb78b7361ed6eb5656b612ce266fc81da8c8c6cb04116fc29b5e1d09a02f6c0f387f6d97a1ce9bdbbeb2d874832ae2d2971e70144ea039c710dccab5fb0a36cb14268a83c9b435c1e7318e7915518b68c8ed056b104e76166d6cabe9b77383f26bcf6a0a0b09d04f37b2a407b47d39421a34f2fbc6e6701a1d5c2e8cbb")]
public abstract class AbstractProgram {

	int rc;

	internal static bool IsSigned ()
	{
		AssemblyName an = Assembly.GetExecutingAssembly ().GetName ();
		byte[] pk = an.GetPublicKey ();
		return ((pk != null) && (pk.Length > 0));
	}

	public AbstractProgram ()
	{
		rc = IsSigned () ? 0 : 1;
		Console.WriteLine ("*{0}* AbstractProgram", rc);
	}

	public int InstanceTest ()
	{
		return rc;
	}
}

public class Program : AbstractProgram {

	static int Test ()
	{
		return new Program ().InstanceTest ();
	}

	static int Main ()
	{
		try {
			return Test ();
		}
		catch (SecurityException se) {
			// if unsigned the SecurityException will be unhandled
			Console.WriteLine ("*1* Unexpected SecurityException\n{0}", se);
			return 1;
		}
		catch (Exception e) {
			Console.WriteLine ("*2* Unexpected Exception\n{0}", e);
			return 2;
		}
	}
}
