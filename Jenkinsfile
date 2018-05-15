pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                sh 'dotnet clean'
                sh 'dotnet build -c Release'
                sh 'dotnet publish -c Release'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}