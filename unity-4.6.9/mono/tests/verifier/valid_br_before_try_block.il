.assembly extern mscorlib
{
  .ver 2:0:0:0
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 ) // .z\V.4..
}
.assembly 'ltest-07'
{
  .hash algorithm 0x00008004
  .ver  0:0:0:0
}
.module 'ltest-07.exe'



.class public auto ansi beforefieldinit Driver extends [mscorlib]System.Object
{
	.method public static hidebysig default void Main ()  cil managed 
	{
		.entrypoint
		.maxstack 8
		ldc.i4.0
		br MIDDLE

		.try
		{
TRY:
			nop
			leave END
		}
		finally
		{
			endfinally
		}
MIDDLE:
		pop
		br TRY
END:
		ret
	}
}


