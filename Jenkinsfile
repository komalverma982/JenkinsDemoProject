pipeline {
    agent any

    stages {
        stage('Checkout Code') {
            steps {
               git 'https://github.com/komalverma982/JenkinsDemoProject.git'
            }
        }
        stage('Restore nuget') {
            steps {
                bat '"C:\\Users\\komal.verma982\\Downloads\\nuget.exe" restore JenkinsDemoProject.sln'
            }
        }
        stage('Buid') {
            steps {
                bat '"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Enterprise\\MSBuild\\Current\\Bin\\amd64\\MSBuild" JenkinsDemoProject.sln /p:Configuration=Release /p:Platform="Any CPU" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}'
            }
        }
      stage('Test') {
            steps {
               bat 'dotnet test D:/JenkinsDemoProject/JenkinsDemoProject/JenkinsDemoProject.csproj'
            }
        }
    }
}