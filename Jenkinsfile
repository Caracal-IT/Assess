pipeline {
    agent any
    environment {
    	DOCKERHUB_CREDENTIALS=credentials('7d1fe5fe-ee76-43d9-a063-1e382b116917')
    }
    stages {
        stage('Clone sources') {
            steps {
                git branch: 'main',
                       url: 'https://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@github.com/Caracal-IT/Assess.git'
            }
        }
        
        stage('Build') {
            steps {
                sh 'docker-compose -f dockerCompose/docker-compose.yml build'
                sh 'docker tag docker.io/divigraph/assess_mvc:latest divigraph/assess_mvc:v4'
            }
        }
        
        stage('Login') {
            steps {
                sh 'echo $DOCKERHUB_CREDENTIALS_PSW | docker login -u $DOCKERHUB_CREDENTIALS_USR --password-stdin'
            }
        }
        stage('Push') {

            steps {
                sh 'docker push divigraph/assess_mvc:v4'
            }
        }
         stage('Push') {
        
            steps {
                sh 'docker image prune'
            }
         }
    }
}