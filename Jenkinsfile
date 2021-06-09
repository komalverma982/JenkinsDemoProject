pipeline {
    agent any

    stages {
        stage('Checkout Code') {
            steps {
			echo 'Checking out the code'
               git 'https://github.com/komalverma982/JenkinsDemoProject.git'
            }
        }
        stage('Restore Nuget') {
            steps {
			echo 'Restoring nuget pacakges'
                bat '"C:\\Users\\komal.verma982\\Downloads\\nuget.exe" restore JenkinsDemoProject.sln'
            }
        }
        stage('Build') {
            steps {
			echo 'Building'
                bat '"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Enterprise\\MSBuild\\Current\\Bin\\amd64\\MSBuild" JenkinsDemoProject.sln /p:Configuration=Release /p:Platform="Any CPU" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}'
            }
        }
      stage('Test') {
            steps {
			echo 'Running the test'
               bat 'dotnet test D:/JenkinsDemoProject/JenkinsDemoProject/JenkinsDemoProject.csproj'
            }
        }
		stage('Publish HTML reports') {
            steps {
			echo 'publishing HTML report'
               publishHTML([allowMissing: false, alwaysLinkToLastBuild: false, keepAll: false, reportDir: '', reportFiles: 'JenkinsDemoProject\\bin\\Debug\\netcoreapp3.1\\Reports\\Automation_Report\\index.html', reportName: 'HTML Report', reportTitles: ''])
            }
        }
    }
}