//****** Donations are greatly appreciated.  ******
//****** You can donate directly to Jesse through paypal at  https://www.paypal.me/JEtzler   ******

//zoom camera
var distance : float = 60;
var sensitivityDistance : float = 50;
var damping : float = 5;
var minFOV : float = 40;
var maxFOV : float = 60;

function Start () {
	distance = GetComponent.<Camera>().fieldOfView;
}

function Update () {

	distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivityDistance;
	distance = Mathf.Clamp(distance, minFOV, maxFOV);
	GetComponent.<Camera>().fieldOfView = Mathf.Lerp(GetComponent.<Camera>().fieldOfView, distance, Time.deltaTime * damping);
}