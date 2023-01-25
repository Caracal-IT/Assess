pipeline {
    agent any
    environment {
    	DOCKERHUB_CREDENTIALS=credentials('7d1fe5fe-ee76-43d9-a063-1e382b116917')
    }
    stages {
        stage('Clone sources') {
            steps {
                echo "The current build number is ${env.BUILD_NUMBER}"
                git branch: 'main',
                       url: 'https://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@github.com/Caracal-IT/Assess.git'
            }
        }
        /*
        stage('Build') {
            steps {
                sh 'docker-compose -f dockerCompose/docker-compose.yml build web'
            }
        }
        */
        stage('Test') {
            steps {
                sh 'docker-compose -f dockerCompose/docker-compose.yml  run unittests du -h'
                sh 'docker-compose -f dockerCompose/docker-compose.yml  run unittests dotnet test code/test/Caracal.Assess.Application.Tests.Unit/Caracal.Assess.Application.Tests.Unit.csproj'                                                                                                                                                 
            }
        }
        /*
        stage('Login') {
            steps {
                sh 'echo $DOCKERHUB_CREDENTIALS_PSW | docker login -u $DOCKERHUB_CREDENTIALS_USR --password-stdin'
            }
        }
        /*
        stage('Push') {

            steps {
                sh 'docker push divigraph/assess_mvc:$BUILD_NUMBER'
            }
        }*/
         stage('Cleanup') {
        
            steps {
                sh 'docker image rm divigraph/assess_mvc:$BUILD_NUMBER'
            }
         }
    }
}