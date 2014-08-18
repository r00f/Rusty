#pragma strict

     
    //here we delcare the variables
     
    //make a new variable and its a float so it have decimals/ we have more control of how fast we want the player to move
    var moveSpeed : float = 10F;
     
    //we use the update function with is going to be used every frame.
    function Update(){
    
    var translationX : float = Input.GetAxis ("Horizontal") * moveSpeed;
	var translationY : float = Input.GetAxis ("Vertical") * moveSpeed;
	
	translationX *= Time.deltaTime;
	translationY *= Time.deltaTime;
     
    transform.Translate(translationX,0,0);
    transform.Translate(0,translationY,0);
    //okay here we make the player move
    //okay lets see what this does
    //transform (gets the transform of the object/player x,y,z) then we use Translate with is a premade function for the unity engine,
    // okay so its saying Translate(x,y,z) so what we are doing is using the Input.GetAxis("Horizontal") where the x is in the translate function.
    //the Input is gonna return us 1,0,-1 if the key is being pressed or not. we * that with our moveSpeed f.eks if we hit D its gonna return us 1 and we times //that with moveSpeed then we * it with Time.deltatime with is gonna do that its the same for all no matter if you have a slow or fast computer
    // because remember we use the Update fucntion wich is gonna update every frame so that means it will go faster if you got a fast computer than a slow
    }
     
