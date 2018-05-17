 
 Declare @ContractNumber varchar(20)
 Set @ContractNumber = '63/27158'
 select SupervisingUnitHigher.Title VahedNezarat,SupervisingUnit.Title VahedNezaratAlieh
		,moshaver.CompanyName Moshaver,contractor.CompanyName Paymankar
      from Contract
      left outer join OrganizationalChart SupervisingUnitHigher on Contract.SupervisingUnit = SupervisingUnitHigher.ChartNodeId
      left outer join OrganizationalChart SupervisingUnit on Contract.SupervisingUnitHigher = SupervisingUnit.ChartNodeId
      left outer join Contractor moshaver on Contract.ConsultantId = moshaver.ContractorId
      left outer join Contractor on Contract.Contractorid = Contractor.ContractorId
 where ContractNumber = @ContractNumber