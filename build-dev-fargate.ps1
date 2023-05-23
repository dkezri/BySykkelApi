$projectName="OsloBySykkelApi"
$projectNameLower= $projectName.ToLower()

git pull
docker build -f $projectName\Dockerfile -t reforged/$projectNameLower .
aws ecr get-login-password --region eu-north-1 --profile dev | docker login --username AWS --password-stdin 813860826518.dkr.ecr.eu-north-1.amazonaws.com
docker tag reforged/$projectNameLower 813860826518.dkr.ecr.eu-north-1.amazonaws.com/azetsconnect-reforged-$projectNameLower:latest
docker push 813860826518.dkr.ecr.eu-north-1.amazonaws.com/azetsconnect-reforged-$projectNameLower:latest
aws ecs update-service --cluster AzetsConnect-Reforged-Cluster --service AzetsConnect-Reforged-$projectName-Fargate --force-new-deployment --profile dev