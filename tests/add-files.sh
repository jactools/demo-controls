# required:
# az login
az storage fs file create --path controls/pipeline/expectation/file1.json --file-system provider1 --account-name jacdatalakestore --auth-mode login
