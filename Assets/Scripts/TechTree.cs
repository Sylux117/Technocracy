using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TechTree : MonoBehaviour {

	#region Variables

	public Toggle toggle;

	#region Toggles
	#region Tier 0
	public Toggle AlarianEcology;
	public Toggle Habitation;
	public Toggle PlanetarySurvey;
	#endregion
	#region Tier 1
	#region Tier 1 Biology
	public Toggle AlienBiology;
	public Toggle Biogenetics;
	public Toggle Prosthetics;
	public Toggle SocialPhych;
	#endregion
	#region Tier 1 Engineering
	public Toggle MineralProcessing;
	public Toggle CommunicationNetwork;
	public Toggle ConstructorCrews;
	public Toggle PoweredExoskeletons;
	#endregion
	#region Tier 1 Physics
	public Toggle CleanEnergy;
	public Toggle Computers;
	public Toggle AppliedPhysics;
	public Toggle Geophysics;
	#endregion
	#endregion
	#region Tier 2
	#region Tier 2 Engineering
	public Toggle IndustrialBase;
	public Toggle Pioneering;
	public Toggle Robotics;
	public Toggle Vehicles;
	#endregion
	#region Tier 2 Physics
	public Toggle DatabankUplinks;
	public Toggle PowerGrids;
	public Toggle IonThrusters;
	public Toggle Nanotechnology;
	#endregion
	#endregion
	#endregion

	#region Costs
	#region Tier 0
	float AlarianEcologyCost = 5;
	float HabitationCost = 5;
	float PlanetarySurveyCost = 5;
	#endregion
	#region Tier 1
	#region Tier 1 Biology
	float AlienBiologyCost = 15;
	float BiogeneticsCost = 15;
	float ProstheticsCost = 15;
	float SocialPhychCost = 15;
	#endregion
	#region Tier 1 Engineering
	float MineralProcessingCost = 15;
	float CommunicationNetworkCost = 15;
	float ConstructorCrewsCost = 15;
	float PoweredExoskeletonsCost = 15;
	#endregion
	#region Tier 1 Physics
	float CleanEnergyCost = 15;
	float ComputersCost = 15;
	float AppliedPhysicsCost = 15;
	float GeophysicsCost = 15;
	#endregion
	#endregion
	#region Tier 2
	#region Tier 2 Engineering
	float IndustrialBaseCost = 40;
	float PioneeringCost = 40;
	float RoboticsCost = 40;
	float VehiclesCost = 40;
	#endregion
	#region Tier 2 Physics
	float DatabankUplinksCost = 40;
	float PowerGridsCost = 40;
	float IonThrustersCost = 40;
	float NanotechnologyCost = 40;
	#endregion
	#endregion
	#endregion

	#region Researched
	#region Tier 0
	public bool AlarianEcologyResearched = false;
	public bool HabitationResearched = false;
	public bool PlanetarySurveyResearched = false;
	#endregion
	#region Tier 1
	#region Tier 1 Biology
	public bool AlienBiologyResearched = false;
	public bool BiogeneticsResearched = false;
	public bool ProstheticsResearched = false;
	public bool SocialPhychResearched = false;
	#endregion
	#region Tier 1 Engineering
	public bool MineralProcessingResearched = false;
	public bool CommunicationNetworkResearched = false;
	public bool ConstructorCrewsResearched = false;
	public bool PoweredExoskeletonsResearched = false;
	#endregion
	#region Tier 1 Physics
	public bool CleanEnergyResearched = false;
	public bool ComputersResearched = false;
	public bool AppliedPhysicsResearched = false;
	public bool GeophysicsResearched = false;
	#endregion
	#endregion
	#region Tier 2
	#region Tier 2 Engineering
	public bool IndustrialBaseResearched = false;
	public bool PioneeringResearched = false;
	public bool RoboticsResearched = false;
	public bool VehiclesResearched = false;
	#endregion
	#region Tier 2 Physics
	public bool DatabankUplinksResearched = false;
	public bool PowerGridsResearched = false;
	public bool IonThrustersResearched = false;
	public bool NanotechnologyResearched = false;
	#endregion
	#endregion
	#endregion

	public Canvas techCanvas;
	public CityManagement city;
	public float biology;
	public float engineering;
	public float physics;

	#region Tech Improvements Variables
	public GameObject Scientist;
	public GameObject Factory;
	public GameObject Farm;
	public GameObject Solar;
	public GameObject Sensor;
	public GameObject Security;
	public GameObject Scout;
	public bool extraCC = false;
	public bool extraPE = false;
	public bool extraR = false;
	public bool extraB = false;
	public bool extraP = false;
	public bool extraSP = false;
	public bool extraC = false;
	public bool extraAP = false;
	public bool extraDU = false;
	public bool extraN = false;
	#endregion

	#region NextTurn stopper
	public Image BiologyImage;
	public Image PhysicsImage;
	public Image EngineeringImage;
	public bool canResearch = false;
	#endregion

	#endregion

	void Start () {
		techCanvas.gameObject.SetActive (false);
		toggle = GetComponent <Toggle> ();
		city = GameObject.FindGameObjectWithTag ("City").GetComponent <CityManagement> ();
		#region Shuting down toggles
		#region Tier 0
		AlarianEcology.enabled = false;
		Habitation.enabled = false;
		PlanetarySurvey.enabled = false;
		#endregion
		#region Tier 1
		#region Tier 1 Biology
		AlienBiology.enabled = false;
		Biogenetics.enabled = false;
		Prosthetics.enabled = false;
		SocialPhych.enabled = false;
		#endregion
		#region Tier 1 Engineering
		MineralProcessing.enabled = false;
		CommunicationNetwork.enabled = false;
		ConstructorCrews.enabled = false;
		PoweredExoskeletons.enabled = false;
		#endregion
		#region Tier 1 Physics
		CleanEnergy.enabled = false;
		Computers.enabled = false;
		AppliedPhysics.enabled = false;
		Geophysics.enabled = false;
		#endregion
		#endregion
		#region Tier 2
		#region Tier 2 Engineering
		IndustrialBase.enabled = false;
		Pioneering.enabled = false;
		Robotics.enabled = false;
		Vehicles.enabled = false;
		#endregion
		#region Tier 2 Physics
		DatabankUplinks.enabled = false;
		PowerGrids.enabled = false;
		IonThrusters.enabled = false;
		Nanotechnology.enabled = false;
		#endregion
		#endregion
		#endregion
	}

	void Update () {

		if (toggle.isOn == true) {
			techCanvas.gameObject.SetActive (true);
		}

		if (toggle.isOn == false) {
			techCanvas.gameObject.SetActive (false);
		}

		#region Tech avaiable shower
		#region Tier 0
		if (AlarianEcologyCost <= city.biology && !AlarianEcologyResearched) {
			BiologyImage.color = Color.red;
			canResearch = true;
		}
		if (HabitationCost <= city.engineering && !HabitationResearched) {
			EngineeringImage.color = Color.red;
			canResearch = true;
		}
		if (PlanetarySurveyCost <= city.physics && !PlanetarySurveyResearched) {
			PhysicsImage.color = Color.red;
			canResearch = true;
		}
		#endregion
		#region Tier 1
		#region Tier 1 Biology
		if (AlienBiologyCost <= city.biology && !AlienBiologyResearched) {
			BiologyImage.color = Color.red;
			canResearch = true;
		}
		if (BiogeneticsCost <= city.biology && !BiogeneticsResearched) {
			BiologyImage.color = Color.red;
			canResearch = true;
		}
		if (ProstheticsCost <= city.biology && !ProstheticsResearched) {
			BiologyImage.color = Color.red;
			canResearch = true;
		}
		if (SocialPhychCost <= city.biology && !SocialPhychResearched) {
			BiologyImage.color = Color.red;
			canResearch = true;
		}
		#endregion
		#region Tier 1 Engineering
		if (MineralProcessingCost <= city.engineering && !MineralProcessingResearched) {
			EngineeringImage.color = Color.red;
			canResearch = true;
		}
		if (CommunicationNetworkCost <= city.engineering && !CommunicationNetworkResearched) {
			EngineeringImage.color = Color.red;
			canResearch = true;
		}
		if (ConstructorCrewsCost <= city.engineering && !ConstructorCrewsResearched) {
			EngineeringImage.color = Color.red;
			canResearch = true;
		}
		if (PoweredExoskeletonsCost <= city.engineering && !PoweredExoskeletonsResearched) {
			EngineeringImage.color = Color.red;
			canResearch = true;
		}
		#endregion
		#region Tier 1 Physics
		if (CleanEnergyCost <= city.physics && !CleanEnergyResearched) {
			PhysicsImage.color = Color.red;
			canResearch = true;
		}
		if (ComputersCost <= city.physics && !ComputersResearched) {
			PhysicsImage.color = Color.red;
			canResearch = true;
		}
		if (AppliedPhysicsCost <= city.physics && !AppliedPhysicsResearched) {
			PhysicsImage.color = Color.red;
			canResearch = true;
		}
		if (GeophysicsCost <= city.physics && !GeophysicsResearched) {
			PhysicsImage.color = Color.red;
			canResearch = true;
		}
		#endregion
		#endregion
		#region Tier 2
		#region Tier 2 Engineering
		if (IndustrialBaseCost <= city.engineering && !IndustrialBaseResearched) {
			EngineeringImage.color = Color.red;
			canResearch = true;
		}
		if (PioneeringCost <= city.engineering && !PioneeringResearched) {
			EngineeringImage.color = Color.red;
			canResearch = true;
		}
		if (RoboticsCost <= city.engineering && !RoboticsResearched) {
			EngineeringImage.color = Color.red;
			canResearch = true;
		}
		if (VehiclesCost <= city.engineering && !VehiclesResearched) {
			EngineeringImage.color = Color.red;
			canResearch = true;
		}
		#endregion
		#region Tier 2 Physics
		if (DatabankUplinksCost <= city.physics && !DatabankUplinksResearched) {
			PhysicsImage.color = Color.red;
			canResearch = true;
		}
		if (PowerGridsCost <= city.physics && !PowerGridsResearched) {
			PhysicsImage.color = Color.red;
			canResearch = true;
		}
		if (IonThrustersCost <= city.physics && !IonThrustersResearched) {
			PhysicsImage.color = Color.red;
			canResearch = true;
		}
		if (NanotechnologyCost <= city.physics && !NanotechnologyResearched) {
			PhysicsImage.color = Color.red;
			canResearch = true;
		}
		#endregion
		#endregion
		if (!canResearch) {
			BiologyImage.color = new Color (255, 255, 255, 100);
			EngineeringImage.color = new Color (255, 255, 255, 100);
			PhysicsImage.color = new Color (255, 255, 255, 100);
		}
		#endregion

		#region Activate Toggle
		#region Tier 0
		if (city.biology >= AlarianEcologyCost && !AlarianEcologyResearched) {
			AlarianEcology.enabled = true;
		}

		if (city.engineering >= HabitationCost && !HabitationResearched) {
			Habitation.enabled = true;
		}

		if (city.physics >= PlanetarySurveyCost && !PlanetarySurveyResearched) {
			PlanetarySurvey.enabled = true;
		}

		#endregion
		#region Tier 1
		#region Tier 1 Biology

		if (city.biology >= AlienBiologyCost && !AlienBiologyResearched && AlarianEcologyResearched) {
			AlienBiology.enabled = true;
		}

		if (city.biology >= BiogeneticsCost && !BiogeneticsResearched && AlarianEcologyResearched) {
			Biogenetics.enabled = true;
		}

		if (city.biology >= ProstheticsCost && !ProstheticsResearched && AlarianEcologyResearched) {
			Prosthetics.enabled = true;
		}

		if (city.biology >= SocialPhychCost && !SocialPhychResearched && AlarianEcologyResearched) {
			SocialPhych.enabled = true;
		}

		#endregion
		#region Tier 1 Engineering

		if (city.engineering >= MineralProcessingCost && !MineralProcessingResearched && HabitationResearched) {
			MineralProcessing.enabled = true;
		}

		if (city.engineering >= CommunicationNetworkCost && !CommunicationNetworkResearched && HabitationResearched) {
			CommunicationNetwork.enabled = true;
		}

		if (city.engineering >= ConstructorCrewsCost && !ConstructorCrewsResearched && HabitationResearched) {
			ConstructorCrews.enabled = true;
		}

		if (city.engineering >= PoweredExoskeletonsCost && !PoweredExoskeletonsResearched && HabitationResearched && ComputersResearched) {
			PoweredExoskeletons.enabled = true;
		}

		#endregion
		#region Tier 1 Physics

		if (city.physics >= CleanEnergyCost && !CleanEnergyResearched && PlanetarySurveyResearched) {
			CleanEnergy.enabled = true;
		}

		if (city.physics >= ComputersCost && !ComputersResearched && PlanetarySurveyResearched) {
			Computers.enabled = true;
		}

		if (city.physics >= AppliedPhysicsCost && !AppliedPhysicsResearched && PlanetarySurveyResearched) {
			AppliedPhysics.enabled = true;
		}

		if (city.physics >= GeophysicsCost && !GeophysicsResearched && PlanetarySurveyResearched) {
			Geophysics.enabled = true;
		}

		#endregion
		#endregion
		#region Tier 2
		#region Tier 2 Engineering

		if (city.engineering >= IndustrialBaseCost && !IndustrialBaseResearched && MineralProcessingResearched) {
			IndustrialBase.enabled = true;
		}

		if (city.engineering >= PioneeringCost && !PioneeringResearched && CommunicationNetworkResearched) {
			Pioneering.enabled = true;
		}

		if (city.engineering >= RoboticsCost && !RoboticsResearched && PoweredExoskeletonsResearched) {
			Robotics.enabled = true;
		}

		if (city.engineering >= VehiclesCost && !VehiclesResearched && ConstructorCrewsResearched) {
			Vehicles.enabled = true;
		}

		#endregion
		#region Tier 2 Physics

		if (city.physics >= DatabankUplinksCost && !DatabankUplinksResearched && ComputersResearched) {
			DatabankUplinks.enabled = true;
		}

		if (city.physics >= PowerGridsCost && !PowerGridsResearched && CleanEnergyResearched) {
			PowerGrids.enabled = true;
		}

		if (city.physics >= IonThrustersCost && !IonThrustersResearched && GeophysicsResearched) {
			IonThrusters.enabled = true;
		}

		if (city.physics >= NanotechnologyCost && !NanotechnologyResearched && AppliedPhysicsResearched) {
			Nanotechnology.enabled = true;
		}

		#endregion
		#endregion
		#endregion

		#region Buy Tech
		#region Tier 0
		if (AlarianEcology.isOn == true) {
			AlarianEcologyResearched = true;
			city.ResearchPay(0,AlarianEcologyCost);
			AlarianEcology.isOn = false;
			AlarianEcology.enabled = false;
			AlarianEcology.gameObject.SetActive(false);
			canResearch = false;
		}

		if (Habitation.isOn == true) {
			HabitationResearched = true;
			city.ResearchPay(1,HabitationCost);
			Habitation.isOn = false;
			Habitation.enabled = false;
			Habitation.gameObject.SetActive(false);
			canResearch = false;
		}

		if (PlanetarySurvey.isOn == true) {
			PlanetarySurveyResearched = true;
			city.ResearchPay(2,PlanetarySurveyCost);
			PlanetarySurvey.isOn = false;
			PlanetarySurvey.enabled = false;
			PlanetarySurvey.gameObject.SetActive(false);
			canResearch = false;
		}
		#endregion
		#region Tier 1
		#region Tier 1 Biology

		if (AlienBiology.isOn == true) {
			AlienBiologyResearched = true;
			city.ResearchPay(0,AlienBiologyCost);
			AlienBiology.isOn = false;
			AlienBiology.enabled = false;
			AlienBiology.gameObject.SetActive(false);
			canResearch = false;
		}

		if (Biogenetics.isOn == true) {
			BiogeneticsResearched = true;
			city.ResearchPay(0,BiogeneticsCost);
			Biogenetics.isOn = false;
			Biogenetics.enabled = false;
			Biogenetics.gameObject.SetActive(false);
			canResearch = false;
		}

		if (Prosthetics.isOn == true) {
			ProstheticsResearched = true;
			city.ResearchPay(0,ProstheticsCost);
			Prosthetics.isOn = false;
			Prosthetics.enabled = false;
			Prosthetics.gameObject.SetActive(false);
			canResearch = false;
		}

		if (SocialPhych.isOn == true) {
			SocialPhychResearched = true;
			city.ResearchPay(0,SocialPhychCost);
			SocialPhych.isOn = false;
			SocialPhych.enabled = false;
			SocialPhych.gameObject.SetActive(false);
			canResearch = false;
		}

		#endregion
		#region Tier 1 Engineering

		if (MineralProcessing.isOn == true) {
			MineralProcessingResearched = true;
			city.ResearchPay(1,MineralProcessingCost);
			MineralProcessing.isOn = false;
			MineralProcessing.enabled = false;
			MineralProcessing.gameObject.SetActive(false);
			canResearch = false;
		}

		if (CommunicationNetwork.isOn == true) {
			CommunicationNetworkResearched = true;
			city.ResearchPay(1,CommunicationNetworkCost);
			CommunicationNetwork.isOn = false;
			CommunicationNetwork.enabled = false;
			CommunicationNetwork.gameObject.SetActive(false);
			canResearch = false;
		}

		if (ConstructorCrews.isOn == true) {
			ConstructorCrewsResearched = true;
			city.ResearchPay(1,ConstructorCrewsCost);
			ConstructorCrews.isOn = false;
			ConstructorCrews.enabled = false;
			ConstructorCrews.gameObject.SetActive(false);
			canResearch = false;
		}

		if (PoweredExoskeletons.isOn == true) {
			PoweredExoskeletonsResearched = true;
			city.ResearchPay(1,PoweredExoskeletonsCost);
			PoweredExoskeletons.isOn = false;
			PoweredExoskeletons.enabled = false;
			PoweredExoskeletons.gameObject.SetActive(false);
			canResearch = false;
		}

		#endregion
		#region Tier 1 Physics

		if (CleanEnergy.isOn == true) {
			CleanEnergyResearched = true;
			city.ResearchPay(2,CleanEnergyCost);
			CleanEnergy.isOn = false;
			CleanEnergy.enabled = false;
			CleanEnergy.gameObject.SetActive(false);
			canResearch = false;
		}

		if (Computers.isOn == true) {
			ComputersResearched = true;
			city.ResearchPay(2,ComputersCost);
			Computers.isOn = false;
			Computers.enabled = false;
			Computers.gameObject.SetActive(false);
			canResearch = false;
		}

		if (AppliedPhysics.isOn == true) {
			AppliedPhysicsResearched = true;
			city.ResearchPay(2,AppliedPhysicsCost);
			AppliedPhysics.isOn = false;
			AppliedPhysics.enabled = false;
			AppliedPhysics.gameObject.SetActive(false);
			canResearch = false;
		}

		if (Geophysics.isOn == true) {
			GeophysicsResearched = true;
			city.ResearchPay(2,GeophysicsCost);
			Geophysics.isOn = false;
			Geophysics.enabled = false;
			Geophysics.gameObject.SetActive(false);
			canResearch = false;
		}

		#endregion
		#endregion
		#region Tier 2
		#region Tier 2 Engineering

		if (IndustrialBase.isOn == true) {
			IndustrialBaseResearched = true;
			city.ResearchPay(1,IndustrialBaseCost);
			IndustrialBase.isOn = false;
			IndustrialBase.enabled = false;
			IndustrialBase.gameObject.SetActive(false);
			canResearch = false;
		}

		if (Pioneering.isOn == true) {
			PioneeringResearched = true;
			city.ResearchPay(1,PioneeringCost);
			Pioneering.isOn = false;
			Pioneering.enabled = false;
			Pioneering.gameObject.SetActive(false);
			canResearch = false;
		}

		if (Robotics.isOn == true) {
			RoboticsResearched = true;
			city.ResearchPay(1,RoboticsCost);
			Robotics.isOn = false;
			Robotics.enabled = false;
			Robotics.gameObject.SetActive(false);
			canResearch = false;
		}

		if (Vehicles.isOn == true) {
			VehiclesResearched = true;
			city.ResearchPay(1,VehiclesCost);
			Vehicles.isOn = false;
			Vehicles.enabled = false;
			Vehicles.gameObject.SetActive(false);
			canResearch = false;
		}

		#endregion
		#region Tier 2 Physics

		if (DatabankUplinks.isOn == true) {
			DatabankUplinksResearched = true;
			city.ResearchPay(2,DatabankUplinksCost);
			DatabankUplinks.isOn = false;
			DatabankUplinks.enabled = false;
			DatabankUplinks.gameObject.SetActive(false);
			canResearch = false;
		}

		if (PowerGrids.isOn == true) {
			PowerGridsResearched = true;
			city.ResearchPay(2,PowerGridsCost);
			PowerGrids.isOn = false;
			PowerGrids.enabled = false;
			PowerGrids.gameObject.SetActive(false);
			canResearch = false;
		}

		if (IonThrusters.isOn == true) {
			IonThrustersResearched = true;
			city.ResearchPay(2,IonThrustersCost);
			IonThrusters.isOn = false;
			IonThrusters.enabled = false;
			IonThrusters.gameObject.SetActive(false);
			canResearch = false;
		}

		if (Nanotechnology.isOn == true) {
			NanotechnologyResearched = true;
			city.ResearchPay(2,NanotechnologyCost);
			Nanotechnology.isOn = false;
			Nanotechnology.enabled = false;
			Nanotechnology.gameObject.SetActive(false);
			canResearch = false;
		}

		#endregion
		#endregion
		#endregion

		#region Tech improvements
		#region Tier 0
		if (!AlarianEcologyResearched){
			Farm.SetActive (false);
		} else {
			Farm.SetActive (true);
		}
		if (!HabitationResearched) {
			Scout.SetActive (false);
		} else {
			Scout.SetActive (true);
		}
		if (!PlanetarySurveyResearched) {
			Scientist.SetActive (false);
		} else {
			Scientist.SetActive (true);
		}
		#endregion
		#region Tier 1
		#region Tier 1 Biology
		if (BiogeneticsResearched && !extraB) {
			city.extraBiology += 1;
			extraB = true;
		}
		if (ProstheticsResearched && !extraP) {
			city.extra += 3;
			extraP = true;
		}
		if (SocialPhychResearched && !extraSP) {
			city.extraBiology += 1;
			city.extraPhysics += 1;
			city.extraEngineering += 1;
			extraSP = true;
		}
		#endregion
		#region Tier 1 Engineering

		if (ConstructorCrewsResearched && !extraCC) {
			city.extra += 3;
			extraCC = true;
		}

		if (PoweredExoskeletonsResearched && !extraPE) {
			city.extra += 3;
			extraPE = true;
		}
		#endregion
		#region Tier 1 Physics
		if (!CleanEnergyResearched) {
			Solar.SetActive(false);
		} else {
			Solar.SetActive(true);
		}
		if (ComputersResearched && !extraC) {
			city.extraBiology += 1;
			city.extraPhysics += 1;
			city.extraEngineering += 1;
			extraC = true;
		}
		if (AppliedPhysicsResearched && !extraAP) {
			city.extra += 3;
			extraAP = true;
			Security.SetActive(true);
		} else if (!AppliedPhysicsResearched) {Security.SetActive(false);}
		#endregion
		#endregion
		#region Tier 2
		#region Tier 2 Engineering
		if (!IndustrialBaseResearched) {
			Factory.SetActive (false);
		} else {
			Factory.SetActive (true);
		}

		if (RoboticsResearched && !extraR) {
			city.extra += 3;
			extraR = true;
		}
		#endregion
		#region Tier 2 Physics
		if (DatabankUplinksResearched && !extraDU) {
			city.extraBiology += 1;
			city.extraPhysics += 1;
			city.extraEngineering += 1;
			Sensor.SetActive(true);
			extraDU = true;
		} else if (!DatabankUplinksResearched) {Sensor.SetActive(false);}
		if (NanotechnologyResearched && !extraN) {
			city.extra += 3;
			extraN = true;
		}
		#endregion
		#endregion
		#endregion
	
	}

}
