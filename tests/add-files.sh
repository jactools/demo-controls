# required:
# az login
az storage fs file create --path controls/pipeline/expectation/20220513-dataobjectA-expectations.json --file-system provider1 --account-name jacdatalakestore --auth-mode login
