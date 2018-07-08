Define Class FingerprintReader as Custom 

	Procedure Match
	Parameters xmlFmdSaved, xmlFdmCaptured

		*!*	Create .Net main componente 
		fingerprintBridge = Createobject("Opa.Interop.Com.Fingerprint")

		*!*	Launch capture	
		resultMatch = fingerprintBridge.MatchFingerprint(xmlFmdSaved, xmlFdmCaptured)

		Return resultMatch 		
	Endproc 

	Procedure Capture 
		*!*	Create .Net main componente 
		fingerprintBridge = Createobject("Opa.Interop.Com.Fingerprint")

		*!*	Create And asociate handler for delegate .Net capture 
		eventFingerprint  = Createobject("IFingerprintCaptureCallback")		
		Eventhandler(fingerprintBridge, eventFingerprint)

		*!*	Launch capture	
		resultInitCapture = fingerprintBridge.CaptureFingerprint()

		*!*	Reader are ready listening		
		If (resultInitCapture.Result)
			this.OnReadyCapture()
		Else  
			this.OnFailCapture(resultInitCapture.Message)
		Endif 
	
	Endproc 

	*!*	when capture start 		
	Procedure OnReadyCapture
	Endproc 
	
	Procedure OnFailCapture 
	Parameters message
	Endproc 
	
Enddefine 


Define Class IFingerprintCaptureCallback as Session Olepublic 
Implements IFingerprintCallback In "Opa.Interop.Com.Fingerprint"

	Procedure IFingerprintCallback_CaptureProcessed(resultCapture) as VOID 
		If (!resultCapture.Result)
			fingerprintProcessed.OnFailFingerprintProcessed(resultCapture.Message)
			Return 
		Endif 
		
		fingerprintProcessed.OnFingerprintProcesed(resultCapture.XmlFmd, resultCapture.ImageFingerprints, resultCapture.StringImageFingerprints, resultCapture.FileFingerprintImage )
	Endproc 

Enddefine  


Define Class IFingerprintProcessed as Custom 
	Procedure OnFingerprintProcesed
	Parameters xmlFmdData, bitmap, stringBitmap, fileBitmap  
	Endproc 
	
	Procedure OnFailFingerprintProcessed
	Parameters errorMessage
	Endproc 	
Enddefine 