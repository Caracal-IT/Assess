pipeline {
    agent any
    stages {
        stage('Clone sources') {
            steps {
                git branch: 'main',
                       url: 'https://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@github.com/Caracal-IT/Assess.git'
            }
        }
        
        stage('Build 2') {
            steps {
                sh 'docker-compose -f dockerCompose/docker-compose.yml build'
                sh 'docker tag docker.io/divigraph/assess_mvc:v2 divigraph/assess_mvc:v3'
            }
        }
    }
}