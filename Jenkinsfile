// Define your image propertes here
def imageName = 'zoopla-selenium-tests'
def imageTag = 'latest'
def containerName = UUID.randomUUID().toString() 

// pass your parameters from Jenkins job like below
def baseUrl = params.BASEURL
def browser = params.BROWSER

node {
    
    stage('Checkout') {
        deleteDir()
        checkout scm
    }
	
    stage('BuildAndRunTests') {
        def taggedImageName = "${imageName}:${imageTag}"
        
        //Build docker container image
        docker.build(taggedImageName,  "--no-cache .")
		
		// Run docker container
		// Paremeters passed to docker contaoiner as environment variables, which then are passed to Dotnet Tests
        sh 'docker run --name ' + containerName + ' -e "' + baseUrl + '" -e "' + browser + '" ' + taggedImageName
        
        //Clean up
        sh 'docker container rm -f ' + containerName
        sh 'docker rmi -f '+ imageName
        
        //Use this to remove any spurious images and containers if neccessary
        /*
        sh 'docker container prune -f'
        sh 'docker image prune -f'
        */
        
        sh 'docker container ls -a'
        sh 'docker image ls -a'
    }
}
