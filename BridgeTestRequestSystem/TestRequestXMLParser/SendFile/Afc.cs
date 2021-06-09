/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TestRequestXMLParser.SendFile
{
		[XmlRoot(ElementName = "StringParameter", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class StringParameter
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
			[XmlElement(ElementName = "Comment", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Comment Comment { get; set; }
		}

		[XmlRoot(ElementName = "ParameterTree", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class ParameterTree
		{
			[XmlElement(ElementName = "StringParameter", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<StringParameter> StringParameter { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlElement(ElementName = "ParameterTree", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<ParameterTree> ParameterTrees { get; set; }
			[XmlElement(ElementName = "IntParameter", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<IntParameter> IntParameter { get; set; }
			[XmlElement(ElementName = "FloatParameter", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<FloatParameter> FloatParameter { get; set; }
		}

		[XmlRoot(ElementName = "CRTSprungMass", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTSprungMass
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "cgHeight")]
			public string CgHeight { get; set; }
			[XmlAttribute(AttributeName = "cgX")]
			public string CgX { get; set; }
			[XmlAttribute(AttributeName = "cgY")]
			public string CgY { get; set; }
			[XmlAttribute(AttributeName = "ixx")]
			public string Ixx { get; set; }
			[XmlAttribute(AttributeName = "ixz")]
			public string Ixz { get; set; }
			[XmlAttribute(AttributeName = "iyy")]
			public string Iyy { get; set; }
			[XmlAttribute(AttributeName = "izz")]
			public string Izz { get; set; }
			[XmlAttribute(AttributeName = "ixy")]
			public string Ixy { get; set; }
			[XmlAttribute(AttributeName = "iyz")]
			public string Iyz { get; set; }
			[XmlAttribute(AttributeName = "mass")]
			public string Mass { get; set; }
			[XmlAttribute(AttributeName = "front_cgX")]
			public string Front_cgX { get; set; }
			[XmlAttribute(AttributeName = "front_cgY")]
			public string Front_cgY { get; set; }
			[XmlAttribute(AttributeName = "front_cgZ")]
			public string Front_cgZ { get; set; }
			[XmlAttribute(AttributeName = "front_ixx")]
			public string Front_ixx { get; set; }
			[XmlAttribute(AttributeName = "front_ixz")]
			public string Front_ixz { get; set; }
			[XmlAttribute(AttributeName = "front_iyy")]
			public string Front_iyy { get; set; }
			[XmlAttribute(AttributeName = "front_izz")]
			public string Front_izz { get; set; }
			[XmlAttribute(AttributeName = "front_ixy")]
			public string Front_ixy { get; set; }
			[XmlAttribute(AttributeName = "front_iyz")]
			public string Front_iyz { get; set; }
			[XmlAttribute(AttributeName = "front_mass")]
			public string Front_mass { get; set; }
			[XmlAttribute(AttributeName = "rear_cgX")]
			public string Rear_cgX { get; set; }
			[XmlAttribute(AttributeName = "rear_cgY")]
			public string Rear_cgY { get; set; }
			[XmlAttribute(AttributeName = "rear_cgZ")]
			public string Rear_cgZ { get; set; }
			[XmlAttribute(AttributeName = "rear_ixx")]
			public string Rear_ixx { get; set; }
			[XmlAttribute(AttributeName = "rear_ixz")]
			public string Rear_ixz { get; set; }
			[XmlAttribute(AttributeName = "rear_iyy")]
			public string Rear_iyy { get; set; }
			[XmlAttribute(AttributeName = "rear_izz")]
			public string Rear_izz { get; set; }
			[XmlAttribute(AttributeName = "rear_ixy")]
			public string Rear_ixy { get; set; }
			[XmlAttribute(AttributeName = "rear_iyz")]
			public string Rear_iyz { get; set; }
			[XmlAttribute(AttributeName = "rear_mass")]
			public string Rear_mass { get; set; }
			[XmlAttribute(AttributeName = "wheelbase")]
			public string Wheelbase { get; set; }
			[XmlAttribute(AttributeName = "graphicsCmdFile")]
			public string GraphicsCmdFile { get; set; }
			[XmlAttribute(AttributeName = "complianceLocation")]
			public string ComplianceLocation { get; set; }
			[XmlAttribute(AttributeName = "torsionalStiffness")]
			public string TorsionalStiffness { get; set; }
			[XmlAttribute(AttributeName = "verticalBendingStiffness")]
			public string VerticalBendingStiffness { get; set; }
			[XmlAttribute(AttributeName = "lateralBendingStiffness")]
			public string LateralBendingStiffness { get; set; }
			[XmlAttribute(AttributeName = "verticalStiffness")]
			public string VerticalStiffness { get; set; }
			[XmlAttribute(AttributeName = "lateralStiffness")]
			public string LateralStiffness { get; set; }
			[XmlAttribute(AttributeName = "axialStiffness")]
			public string AxialStiffness { get; set; }
			[XmlAttribute(AttributeName = "torsionalDamping")]
			public string TorsionalDamping { get; set; }
			[XmlAttribute(AttributeName = "verticalBendingDamping")]
			public string VerticalBendingDamping { get; set; }
			[XmlAttribute(AttributeName = "lateralBendingDamping")]
			public string LateralBendingDamping { get; set; }
			[XmlAttribute(AttributeName = "verticalDamping")]
			public string VerticalDamping { get; set; }
			[XmlAttribute(AttributeName = "lateralDamping")]
			public string LateralDamping { get; set; }
			[XmlAttribute(AttributeName = "axialDamping")]
			public string AxialDamping { get; set; }
			[XmlAttribute(AttributeName = "torsionalStiffnessActiveFlag")]
			public string TorsionalStiffnessActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "verticalBendingStiffnessActiveFlag")]
			public string VerticalBendingStiffnessActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "lateralBendingStiffnessActiveFlag")]
			public string LateralBendingStiffnessActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "verticalStiffnessActiveFlag")]
			public string VerticalStiffnessActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "lateralStiffnessActiveFlag")]
			public string LateralStiffnessActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "axialStiffnessActiveFlag")]
			public string AxialStiffnessActiveFlag { get; set; }
		}

		[XmlRoot(ElementName = "SensorPoint", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class SensorPoint
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "location")]
			public string Location { get; set; }
			[XmlAttribute(AttributeName = "yaw")]
			public string Yaw { get; set; }
			[XmlAttribute(AttributeName = "pitch")]
			public string Pitch { get; set; }
			[XmlAttribute(AttributeName = "roll")]
			public string Roll { get; set; }
		}

		[XmlRoot(ElementName = "cgReferencePoint", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CgReferencePoint
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "location")]
			public string Location { get; set; }
		}

		[XmlRoot(ElementName = "Spline", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class Spline
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "interpolation_method")]
			public string Interpolation_method { get; set; }
			[XmlAttribute(AttributeName = "xUnit")]
			public string XUnit { get; set; }
			[XmlAttribute(AttributeName = "yUnit")]
			public string YUnit { get; set; }
			[XmlText]
			public string Text { get; set; }
			[XmlElement(ElementName = "Comment", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Comment Comment { get; set; }
			[XmlAttribute(AttributeName = "xLabel")]
			public string XLabel { get; set; }
			[XmlAttribute(AttributeName = "yLabel")]
			public string YLabel { get; set; }
			[XmlAttribute(AttributeName = "datablock")]
			public string Datablock { get; set; }
		}

		[XmlRoot(ElementName = "OutputChannel", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class OutputChannel
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "resultSet")]
			public string ResultSet { get; set; }
			[XmlAttribute(AttributeName = "component")]
			public string Component { get; set; }
			[XmlAttribute(AttributeName = "scale")]
			public string Scale { get; set; }
			[XmlAttribute(AttributeName = "offset")]
			public string Offset { get; set; }
			[XmlAttribute(AttributeName = "isLive")]
			public string IsLive { get; set; }
		}

		[XmlRoot(ElementName = "CRTSensor", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTSensor
		{
			[XmlElement(ElementName = "OutputChannel", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<OutputChannel> OutputChannel { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "type")]
			public string Type { get; set; }
			[XmlAttribute(AttributeName = "drdFile")]
			public string DrdFile { get; set; }
			[XmlAttribute(AttributeName = "triggerS")]
			public string TriggerS { get; set; }
			[XmlAttribute(AttributeName = "typeOfFreedom")]
			public string TypeOfFreedom { get; set; }
			[XmlAttribute(AttributeName = "angleMethod")]
			public string AngleMethod { get; set; }
			[XmlAttribute(AttributeName = "iBody")]
			public string IBody { get; set; }
			[XmlAttribute(AttributeName = "iLoc")]
			public string ILoc { get; set; }
			[XmlAttribute(AttributeName = "iOri")]
			public string IOri { get; set; }
			[XmlAttribute(AttributeName = "jBody")]
			public string JBody { get; set; }
			[XmlAttribute(AttributeName = "jLoc")]
			public string JLoc { get; set; }
			[XmlAttribute(AttributeName = "jOri")]
			public string JOri { get; set; }
			[XmlAttribute(AttributeName = "refBody")]
			public string RefBody { get; set; }
			[XmlAttribute(AttributeName = "refLoc")]
			public string RefLoc { get; set; }
			[XmlAttribute(AttributeName = "refOri")]
			public string RefOri { get; set; }
		}

		[XmlRoot(ElementName = "CRTFuelConfiguration", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTFuelConfiguration
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "setupActiveFlag")]
			public string SetupActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "runningActiveFlag")]
			public string RunningActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "location")]
			public string Location { get; set; }
			[XmlAttribute(AttributeName = "setupMass")]
			public string SetupMass { get; set; }
			[XmlAttribute(AttributeName = "runningMass")]
			public string RunningMass { get; set; }
		}

		[XmlRoot(ElementName = "CRTDriverConfiguration", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTDriverConfiguration
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "setupActiveFlag")]
			public string SetupActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "runningActiveFlag")]
			public string RunningActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "location")]
			public string Location { get; set; }
			[XmlAttribute(AttributeName = "mass")]
			public string Mass { get; set; }
		}

		[XmlRoot(ElementName = "CRTBallast", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTBallast
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "setupActiveFlag")]
			public string SetupActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "runningActiveFlag")]
			public string RunningActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "location")]
			public string Location { get; set; }
			[XmlAttribute(AttributeName = "mass")]
			public string Mass { get; set; }
		}

		[XmlRoot(ElementName = "CRTBodyAuxiliaryMass", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTBodyAuxiliaryMass
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "location")]
			public string Location { get; set; }
			[XmlAttribute(AttributeName = "mass")]
			public string Mass { get; set; }
		}

		[XmlRoot(ElementName = "CRTBodySetupData", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTBodySetupData
		{
			[XmlElement(ElementName = "CRTFuelConfiguration", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTFuelConfiguration CRTFuelConfiguration { get; set; }
			[XmlElement(ElementName = "CRTDriverConfiguration", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTDriverConfiguration CRTDriverConfiguration { get; set; }
			[XmlElement(ElementName = "CRTBallast", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTBallast> CRTBallast { get; set; }
			[XmlElement(ElementName = "CRTBodyAuxiliaryMass", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTBodyAuxiliaryMass> CRTBodyAuxiliaryMass { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "massSetupMethod")]
			public string MassSetupMethod { get; set; }
		}

		[XmlRoot(ElementName = "CRTCrossWeightAdjustment", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTCrossWeightAdjustment
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "crossWeightActiveFlag")]
			public string CrossWeightActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "crossWeightMethod")]
			public string CrossWeightMethod { get; set; }
			[XmlAttribute(AttributeName = "crossWeightForce")]
			public string CrossWeightForce { get; set; }
			[XmlAttribute(AttributeName = "crossWeightRatio")]
			public string CrossWeightRatio { get; set; }
			[XmlAttribute(AttributeName = "unhookedForce")]
			public string UnhookedForce { get; set; }
			[XmlAttribute(AttributeName = "unhookedRatio")]
			public string UnhookedRatio { get; set; }
		}

		[XmlRoot(ElementName = "CRTVehicleGraphics", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTVehicleGraphics
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "graphicsCmdFile")]
			public string GraphicsCmdFile { get; set; }
			[XmlAttribute(AttributeName = "xgrActiveFlag")]
			public string XgrActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "bodyFile")]
			public string BodyFile { get; set; }
			[XmlAttribute(AttributeName = "graphicsType")]
			public string GraphicsType { get; set; }
			[XmlAttribute(AttributeName = "leftFrontWheelFile")]
			public string LeftFrontWheelFile { get; set; }
			[XmlAttribute(AttributeName = "leftRearWheelFile")]
			public string LeftRearWheelFile { get; set; }
			[XmlAttribute(AttributeName = "rightFrontWheelFile")]
			public string RightFrontWheelFile { get; set; }
			[XmlAttribute(AttributeName = "rightRearWheelFile")]
			public string RightRearWheelFile { get; set; }
			[XmlAttribute(AttributeName = "engineGraphicsActiveFlag")]
			public string EngineGraphicsActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "engineGraphicsFile")]
			public string EngineGraphicsFile { get; set; }
			[XmlAttribute(AttributeName = "auxGraphicsActiveFlag")]
			public string AuxGraphicsActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "frontTwinWheelsActiveFlag")]
			public string FrontTwinWheelsActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "middleTwinWheelsActiveFlag")]
			public string MiddleTwinWheelsActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "rearTwinWheelsActiveFlag")]
			public string RearTwinWheelsActiveFlag { get; set; }
		}

		[XmlRoot(ElementName = "CRTSkidplatePoint", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTSkidplatePoint
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "actionBody")]
			public string ActionBody { get; set; }
			[XmlAttribute(AttributeName = "actionLoc")]
			public string ActionLoc { get; set; }
			[XmlAttribute(AttributeName = "contactStiffness")]
			public string ContactStiffness { get; set; }
			[XmlAttribute(AttributeName = "contactDamping")]
			public string ContactDamping { get; set; }
			[XmlAttribute(AttributeName = "contactExponent")]
			public string ContactExponent { get; set; }
			[XmlAttribute(AttributeName = "contactFrictionCoefficient")]
			public string ContactFrictionCoefficient { get; set; }
		}

		[XmlRoot(ElementName = "CRTAerodynamicForces", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTAerodynamicForces
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "frontDownForceLocation")]
			public string FrontDownForceLocation { get; set; }
			[XmlAttribute(AttributeName = "rearDownForceLocation")]
			public string RearDownForceLocation { get; set; }
			[XmlAttribute(AttributeName = "dragForceLocation")]
			public string DragForceLocation { get; set; }
			[XmlAttribute(AttributeName = "frontDownForceSensor")]
			public string FrontDownForceSensor { get; set; }
			[XmlAttribute(AttributeName = "frontAuxDownForceSensorActiveFlag")]
			public string FrontAuxDownForceSensorActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "frontAuxDownForceSensor")]
			public string FrontAuxDownForceSensor { get; set; }
			[XmlAttribute(AttributeName = "rearDownForceSensor")]
			public string RearDownForceSensor { get; set; }
			[XmlAttribute(AttributeName = "dragForceSensor")]
			public string DragForceSensor { get; set; }
			[XmlAttribute(AttributeName = "frontDownForceShift")]
			public string FrontDownForceShift { get; set; }
			[XmlAttribute(AttributeName = "frontDownForceScale")]
			public string FrontDownForceScale { get; set; }
			[XmlAttribute(AttributeName = "frontDownForceSmoothingTime")]
			public string FrontDownForceSmoothingTime { get; set; }
			[XmlAttribute(AttributeName = "rearDownForceShift")]
			public string RearDownForceShift { get; set; }
			[XmlAttribute(AttributeName = "rearDownForceScale")]
			public string RearDownForceScale { get; set; }
			[XmlAttribute(AttributeName = "rearDownForceSmoothingTime")]
			public string RearDownForceSmoothingTime { get; set; }
			[XmlAttribute(AttributeName = "centerDownForceShift")]
			public string CenterDownForceShift { get; set; }
			[XmlAttribute(AttributeName = "centerDownForceScale")]
			public string CenterDownForceScale { get; set; }
			[XmlAttribute(AttributeName = "centerDownForceSmoothingTime")]
			public string CenterDownForceSmoothingTime { get; set; }
			[XmlAttribute(AttributeName = "dragForceShift")]
			public string DragForceShift { get; set; }
			[XmlAttribute(AttributeName = "dragForceScale")]
			public string DragForceScale { get; set; }
			[XmlAttribute(AttributeName = "dragForceSmoothingTime")]
			public string DragForceSmoothingTime { get; set; }
			[XmlAttribute(AttributeName = "frontDragForceShift")]
			public string FrontDragForceShift { get; set; }
			[XmlAttribute(AttributeName = "frontDragForceScale")]
			public string FrontDragForceScale { get; set; }
			[XmlAttribute(AttributeName = "frontDragForceSmoothingTime")]
			public string FrontDragForceSmoothingTime { get; set; }
			[XmlAttribute(AttributeName = "rearDragForceShift")]
			public string RearDragForceShift { get; set; }
			[XmlAttribute(AttributeName = "rearDragForceScale")]
			public string RearDragForceScale { get; set; }
			[XmlAttribute(AttributeName = "rearDragForceSmoothingTime")]
			public string RearDragForceSmoothingTime { get; set; }
			[XmlAttribute(AttributeName = "frontSideForceShift")]
			public string FrontSideForceShift { get; set; }
			[XmlAttribute(AttributeName = "frontSideForceScale")]
			public string FrontSideForceScale { get; set; }
			[XmlAttribute(AttributeName = "frontSideForceSmoothingTime")]
			public string FrontSideForceSmoothingTime { get; set; }
			[XmlAttribute(AttributeName = "rearSideForceShift")]
			public string RearSideForceShift { get; set; }
			[XmlAttribute(AttributeName = "rearSideForceScale")]
			public string RearSideForceScale { get; set; }
			[XmlAttribute(AttributeName = "rearSideForceSmoothingTime")]
			public string RearSideForceSmoothingTime { get; set; }
			[XmlAttribute(AttributeName = "centerSideForceShift")]
			public string CenterSideForceShift { get; set; }
			[XmlAttribute(AttributeName = "centerSideForceScale")]
			public string CenterSideForceScale { get; set; }
			[XmlAttribute(AttributeName = "centerSideForceSmoothingTime")]
			public string CenterSideForceSmoothingTime { get; set; }
			[XmlAttribute(AttributeName = "rollMomentShift")]
			public string RollMomentShift { get; set; }
			[XmlAttribute(AttributeName = "rollMomentScale")]
			public string RollMomentScale { get; set; }
			[XmlAttribute(AttributeName = "rollMomentSmoothingTime")]
			public string RollMomentSmoothingTime { get; set; }
			[XmlAttribute(AttributeName = "pitchMomentShift")]
			public string PitchMomentShift { get; set; }
			[XmlAttribute(AttributeName = "pitchMomentScale")]
			public string PitchMomentScale { get; set; }
			[XmlAttribute(AttributeName = "pitchMomentSmoothingTime")]
			public string PitchMomentSmoothingTime { get; set; }
			[XmlAttribute(AttributeName = "yawMomentShift")]
			public string YawMomentShift { get; set; }
			[XmlAttribute(AttributeName = "yawMomentScale")]
			public string YawMomentScale { get; set; }
			[XmlAttribute(AttributeName = "yawMomentSmoothingTime")]
			public string YawMomentSmoothingTime { get; set; }
			[XmlAttribute(AttributeName = "compensationTorqueActiveFlag")]
			public string CompensationTorqueActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "compensationTorqueShift")]
			public string CompensationTorqueShift { get; set; }
			[XmlAttribute(AttributeName = "compensationTorqueScale")]
			public string CompensationTorqueScale { get; set; }
			[XmlAttribute(AttributeName = "propertyFile")]
			public string PropertyFile { get; set; }
		}

		[XmlRoot(ElementName = "Subsystem", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class Subsystem
		{
			[XmlElement(ElementName = "CRTSprungMass", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTSprungMass CRTSprungMass { get; set; }
			[XmlElement(ElementName = "SensorPoint", Namespace = "http://www.mscsoftware.com/:vfc")]
			public SensorPoint SensorPoint { get; set; }
			[XmlElement(ElementName = "cgReferencePoint", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CgReferencePoint CgReferencePoint { get; set; }
			[XmlElement(ElementName = "Spline", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline> Spline { get; set; }
			[XmlElement(ElementName = "CRTSensor", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTSensor> CRTSensor { get; set; }
			[XmlElement(ElementName = "CRTBodySetupData", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTBodySetupData CRTBodySetupData { get; set; }
			[XmlElement(ElementName = "CRTCrossWeightAdjustment", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTCrossWeightAdjustment CRTCrossWeightAdjustment { get; set; }
			[XmlElement(ElementName = "CRTVehicleGraphics", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTVehicleGraphics CRTVehicleGraphics { get; set; }
			[XmlElement(ElementName = "CRTSkidplatePoint", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTSkidplatePoint> CRTSkidplatePoint { get; set; }
			[XmlElement(ElementName = "CRTAerodynamicForces", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTAerodynamicForces CRTAerodynamicForces { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlElement(ElementName = "CRTSuspensionGeneralProperties", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTSuspensionGeneralProperties CRTSuspensionGeneralProperties { get; set; }
			[XmlElement(ElementName = "CRTKinematicsPair", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTKinematicsPair CRTKinematicsPair { get; set; }
			[XmlElement(ElementName = "SpringPair", Namespace = "http://www.mscsoftware.com/:vfc")]
			public SpringPair SpringPair { get; set; }
			[XmlElement(ElementName = "DamperPair", Namespace = "http://www.mscsoftware.com/:vfc")]
			public DamperPair DamperPair { get; set; }
			[XmlElement(ElementName = "BumpStopPair", Namespace = "http://www.mscsoftware.com/:vfc")]
			public BumpStopPair BumpStopPair { get; set; }
			[XmlElement(ElementName = "ReboundStopPair", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<ReboundStopPair> ReboundStopPair { get; set; }
			[XmlElement(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline3d> Spline3d { get; set; }
			[XmlElement(ElementName = "CRTInstallationStiffnessPair", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTInstallationStiffnessPair CRTInstallationStiffnessPair { get; set; }
			[XmlElement(ElementName = "CRTSuspensionSetupData", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTSuspensionSetupData CRTSuspensionSetupData { get; set; }
			[XmlElement(ElementName = "CRTCompliancePair", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTCompliancePair> CRTCompliancePair { get; set; }
			[XmlElement(ElementName = "CRTAuxiliaryRollStiffness", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTAuxiliaryRollStiffness CRTAuxiliaryRollStiffness { get; set; }
			[XmlElement(ElementName = "CRTAuxiliaryTranslationalDOFPair", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTAuxiliaryTranslationalDOFPair CRTAuxiliaryTranslationalDOFPair { get; set; }
			[XmlElement(ElementName = "CRTWheelPair", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTWheelPair CRTWheelPair { get; set; }
			[XmlElement(ElementName = "CRTSteeringSystem", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTSteeringSystem CRTSteeringSystem { get; set; }
			[XmlElement(ElementName = "CRTAdvancedSteering", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTAdvancedSteering CRTAdvancedSteering { get; set; }
			[XmlElement(ElementName = "CRTKinematicsData", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTKinematicsData> CRTKinematicsData { get; set; }
			[XmlElement(ElementName = "CRTDriveline", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTDriveline CRTDriveline { get; set; }
			[XmlElement(ElementName = "ParameterTree", Namespace = "http://www.mscsoftware.com/:vfc")]
			public ParameterTree ParameterTree { get; set; }
		}

		[XmlRoot(ElementName = "VectorAttribute", Namespace = "http://www.mscsoftware.com/:afc")]
		public class VectorAttribute
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlText]
			public string Text { get; set; }
		}

		[XmlRoot(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class Spline3d
		{
			[XmlElement(ElementName = "VectorAttribute", Namespace = "http://www.mscsoftware.com/:afc")]
			public List<VectorAttribute> VectorAttribute { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "interpolation_method")]
			public string Interpolation_method { get; set; }
			[XmlAttribute(AttributeName = "xLabel")]
			public string XLabel { get; set; }
			[XmlAttribute(AttributeName = "yLabel")]
			public string YLabel { get; set; }
			[XmlAttribute(AttributeName = "xUnit")]
			public string XUnit { get; set; }
			[XmlAttribute(AttributeName = "yUnit")]
			public string YUnit { get; set; }
			[XmlAttribute(AttributeName = "datablock")]
			public string Datablock { get; set; }
			[XmlAttribute(AttributeName = "zLabel")]
			public string ZLabel { get; set; }
			[XmlAttribute(AttributeName = "zUnit")]
			public string ZUnit { get; set; }
			[XmlElement(ElementName = "Comment", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Comment Comment { get; set; }
		}

		[XmlRoot(ElementName = "CRTSuspensionGeneralProperties", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTSuspensionGeneralProperties
		{
			[XmlElement(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline3d> Spline3d { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "trackWidth")]
			public string TrackWidth { get; set; }
		}

		[XmlRoot(ElementName = "CRTSuspensionData", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTSuspensionData
		{
			[XmlElement(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline3d> Spline3d { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "method")]
			public string Method { get; set; }
			[XmlAttribute(AttributeName = "constant")]
			public string Constant { get; set; }
			[XmlAttribute(AttributeName = "unit")]
			public string Unit { get; set; }
			[XmlAttribute(AttributeName = "mirror")]
			public string Mirror { get; set; }
			[XmlAttribute(AttributeName = "scaleFactor")]
			public string ScaleFactor { get; set; }
		}

		[XmlRoot(ElementName = "CRTKinematics", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTKinematics
		{
			[XmlElement(ElementName = "CRTSuspensionData", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTSuspensionData> CRTSuspensionData { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
		}

		[XmlRoot(ElementName = "CRTKinematicsPair", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTKinematicsPair
		{
			[XmlElement(ElementName = "CRTKinematics", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTKinematics> CRTKinematics { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "symmetry")]
			public string Symmetry { get; set; }
		}

		[XmlRoot(ElementName = "CRTSpringContext", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTSpringContext
		{
			[XmlElement(ElementName = "CRTSuspensionData", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTSuspensionData CRTSuspensionData { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "propertyURI")]
			public string PropertyURI { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "context")]
			public string Context { get; set; }
			[XmlAttribute(AttributeName = "offset")]
			public string Offset { get; set; }
			[XmlAttribute(AttributeName = "installMethod")]
			public string InstallMethod { get; set; }
			[XmlAttribute(AttributeName = "installValue")]
			public string InstallValue { get; set; }
			[XmlAttribute(AttributeName = "installationStiffness")]
			public string InstallationStiffness { get; set; }
			[XmlAttribute(AttributeName = "installationStiffnessActiveFlag")]
			public string InstallationStiffnessActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "multiplicityFlag")]
			public string MultiplicityFlag { get; set; }
			[XmlAttribute(AttributeName = "scaleFactor")]
			public string ScaleFactor { get; set; }
			[XmlAttribute(AttributeName = "multiplicity")]
			public string Multiplicity { get; set; }
			[XmlAttribute(AttributeName = "decouplingFlag")]
			public string DecouplingFlag { get; set; }
		}

		[XmlRoot(ElementName = "Context", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class Context
		{
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "context")]
			public string Contexts { get; set; }
			[XmlAttribute(AttributeName = "offset")]
			public string Offset { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "propertyURI")]
			public string PropertyURI { get; set; }
		}

		[XmlRoot(ElementName = "Spring", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class Spring
		{
			[XmlElement(ElementName = "CRTSpringContext", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTSpringContext CRTSpringContext { get; set; }
			[XmlElement(ElementName = "Context", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Context Context { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "attach_part_1")]
			public string Attach_part_1 { get; set; }
			[XmlAttribute(AttributeName = "attach_part_2")]
			public string Attach_part_2 { get; set; }
			[XmlAttribute(AttributeName = "attach_location_1")]
			public string Attach_location_1 { get; set; }
			[XmlAttribute(AttributeName = "attach_location_2")]
			public string Attach_location_2 { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
		}

		[XmlRoot(ElementName = "SpringPair", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class SpringPair
		{
			[XmlElement(ElementName = "Spring", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spring> Spring { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "symmetry")]
			public string Symmetry { get; set; }
		}

		[XmlRoot(ElementName = "CRTDamperContext", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTDamperContext
		{
			[XmlElement(ElementName = "CRTSuspensionData", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTSuspensionData CRTSuspensionData { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "propertyURI")]
			public string PropertyURI { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "context")]
			public string Context { get; set; }
			[XmlAttribute(AttributeName = "offset")]
			public string Offset { get; set; }
			[XmlAttribute(AttributeName = "scaleFactor")]
			public string ScaleFactor { get; set; }
			[XmlAttribute(AttributeName = "input_stretch")]
			public string Input_stretch { get; set; }
			[XmlAttribute(AttributeName = "output_stretch")]
			public string Output_stretch { get; set; }
			[XmlAttribute(AttributeName = "time_stretch")]
			public string Time_stretch { get; set; }
			[XmlAttribute(AttributeName = "multiplicityFlag")]
			public string MultiplicityFlag { get; set; }
			[XmlAttribute(AttributeName = "multiplicity")]
			public string Multiplicity { get; set; }
		}

		[XmlRoot(ElementName = "Damper", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class Damper
		{
			[XmlElement(ElementName = "CRTDamperContext", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTDamperContext CRTDamperContext { get; set; }
			[XmlElement(ElementName = "Context", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Context Context { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "attach_part_1")]
			public string Attach_part_1 { get; set; }
			[XmlAttribute(AttributeName = "attach_part_2")]
			public string Attach_part_2 { get; set; }
			[XmlAttribute(AttributeName = "attach_location_1")]
			public string Attach_location_1 { get; set; }
			[XmlAttribute(AttributeName = "attach_location_2")]
			public string Attach_location_2 { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
		}

		[XmlRoot(ElementName = "DamperPair", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class DamperPair
		{
			[XmlElement(ElementName = "Damper", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Damper> Damper { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "symmetry")]
			public string Symmetry { get; set; }
		}

		[XmlRoot(ElementName = "CRTBumperContext", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTBumperContext
		{
			[XmlElement(ElementName = "CRTSuspensionData", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTSuspensionData CRTSuspensionData { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "propertyURI")]
			public string PropertyURI { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "context")]
			public string Context { get; set; }
			[XmlAttribute(AttributeName = "offset")]
			public string Offset { get; set; }
			[XmlAttribute(AttributeName = "installMethod")]
			public string InstallMethod { get; set; }
			[XmlAttribute(AttributeName = "installValue")]
			public string InstallValue { get; set; }
			[XmlAttribute(AttributeName = "scaleFactor")]
			public string ScaleFactor { get; set; }
			[XmlAttribute(AttributeName = "multiplicityFlag")]
			public string MultiplicityFlag { get; set; }
			[XmlAttribute(AttributeName = "multiplicity")]
			public string Multiplicity { get; set; }
		}

		[XmlRoot(ElementName = "BumpStop", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class BumpStop
		{
			[XmlElement(ElementName = "CRTBumperContext", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTBumperContext CRTBumperContext { get; set; }
			[XmlElement(ElementName = "Context", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Context Context { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "attach_part_1")]
			public string Attach_part_1 { get; set; }
			[XmlAttribute(AttributeName = "attach_part_2")]
			public string Attach_part_2 { get; set; }
			[XmlAttribute(AttributeName = "attach_location_1")]
			public string Attach_location_1 { get; set; }
			[XmlAttribute(AttributeName = "attach_location_2")]
			public string Attach_location_2 { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "metalToMetalRate")]
			public string MetalToMetalRate { get; set; }
		}

		[XmlRoot(ElementName = "BumpStopPair", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class BumpStopPair
		{
			[XmlElement(ElementName = "BumpStop", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<BumpStop> BumpStop { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "symmetry")]
			public string Symmetry { get; set; }
		}

		[XmlRoot(ElementName = "ReboundStop", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class ReboundStop
		{
			[XmlElement(ElementName = "CRTBumperContext", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTBumperContext CRTBumperContext { get; set; }
			[XmlElement(ElementName = "Context", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Context Context { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "attach_part_1")]
			public string Attach_part_1 { get; set; }
			[XmlAttribute(AttributeName = "attach_part_2")]
			public string Attach_part_2 { get; set; }
			[XmlAttribute(AttributeName = "attach_location_1")]
			public string Attach_location_1 { get; set; }
			[XmlAttribute(AttributeName = "attach_location_2")]
			public string Attach_location_2 { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "metalToMetalRate")]
			public string MetalToMetalRate { get; set; }
		}

		[XmlRoot(ElementName = "ReboundStopPair", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class ReboundStopPair
		{
			[XmlElement(ElementName = "ReboundStop", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<ReboundStop> ReboundStop { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "symmetry")]
			public string Symmetry { get; set; }
		}

		[XmlRoot(ElementName = "CRTInstallationStiffness", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTInstallationStiffness
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "antiRollBarActiveFlag")]
			public string AntiRollBarActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "springActiveFlag")]
			public string SpringActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName = "computationMode")]
			public string ComputationMode { get; set; }
			[XmlAttribute(AttributeName = "mass")]
			public string Mass { get; set; }
			[XmlAttribute(AttributeName = "cutoffFrequency")]
			public string CutoffFrequency { get; set; }
			[XmlAttribute(AttributeName = "dampingRatio")]
			public string DampingRatio { get; set; }
		}

		[XmlRoot(ElementName = "CRTInstallationStiffnessPair", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTInstallationStiffnessPair
		{
			[XmlElement(ElementName = "CRTInstallationStiffness", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTInstallationStiffness> CRTInstallationStiffness { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "symmetry")]
			public string Symmetry { get; set; }
		}

		[XmlRoot(ElementName = "CRTAdjustment", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTAdjustment
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "CRTLengthAdjustment", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTLengthAdjustment
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "CRTForceAdjustment", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTForceAdjustment
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "CRTRideHeightSensor", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTRideHeightSensor
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "location")]
			public string Location { get; set; }
			[XmlAttribute(AttributeName = "rideHeight")]
			public string RideHeight { get; set; }
		}

		[XmlRoot(ElementName = "CRTSuspensionSetupData", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTSuspensionSetupData
		{
			[XmlElement(ElementName = "CRTAdjustment", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTAdjustment> CRTAdjustment { get; set; }
			[XmlElement(ElementName = "CRTLengthAdjustment", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTLengthAdjustment> CRTLengthAdjustment { get; set; }
			[XmlElement(ElementName = "CRTForceAdjustment", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTForceAdjustment> CRTForceAdjustment { get; set; }
			[XmlElement(ElementName = "CRTRideHeightSensor", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTRideHeightSensor> CRTRideHeightSensor { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "wheelAnglesSetupStage")]
			public string WheelAnglesSetupStage { get; set; }
			[XmlAttribute(AttributeName = "camberAngleSetupStage")]
			public string CamberAngleSetupStage { get; set; }
			[XmlAttribute(AttributeName = "toeAngleSetupStage")]
			public string ToeAngleSetupStage { get; set; }
			[XmlAttribute(AttributeName = "indipendentAngleSetupFlag")]
			public string IndipendentAngleSetupFlag { get; set; }
			[XmlAttribute(AttributeName = "rideHeightAdjustmentActiveFlag")]
			public string RideHeightAdjustmentActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "leftBumperClearanceAdjustmentActiveFlag")]
			public string LeftBumperClearanceAdjustmentActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "rightBumperClearanceAdjustmentActiveFlag")]
			public string RightBumperClearanceAdjustmentActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "leftBumperPassiveAdjustmentActiveFlag")]
			public string LeftBumperPassiveAdjustmentActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "rightBumperPassiveAdjustmentActiveFlag")]
			public string RightBumperPassiveAdjustmentActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "leftReboundstopClearanceAdjustmentActiveFlag")]
			public string LeftReboundstopClearanceAdjustmentActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "rightReboundstopClearanceAdjustmentActiveFlag")]
			public string RightReboundstopClearanceAdjustmentActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "leftPinHeightAdjustmentMethod")]
			public string LeftPinHeightAdjustmentMethod { get; set; }
			[XmlAttribute(AttributeName = "rightPinHeightAdjustmentMethod")]
			public string RightPinHeightAdjustmentMethod { get; set; }
			[XmlAttribute(AttributeName = "centerBumperClearanceAdjustmentActiveFlag")]
			public string CenterBumperClearanceAdjustmentActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "centerReboundstopClearanceAdjustmentActiveFlag")]
			public string CenterReboundstopClearanceAdjustmentActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "centerPinHeightAdjustmentMethod")]
			public string CenterPinHeightAdjustmentMethod { get; set; }
			[XmlAttribute(AttributeName = "setupStageBumpersActivity")]
			public string SetupStageBumpersActivity { get; set; }
			[XmlAttribute(AttributeName = "complianceActiveFlag")]
			public string ComplianceActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "directCmplActiveFlag")]
			public string DirectCmplActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "crossCmplActiveFlag")]
			public string CrossCmplActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "dirLongTracCmplActiveFlag")]
			public string DirLongTracCmplActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "dirLongBrakCmplActiveFlag")]
			public string DirLongBrakCmplActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "dirLatCmplActiveFlag")]
			public string DirLatCmplActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "dirAlignCmplActiveFlag")]
			public string DirAlignCmplActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "dirVertCmplActiveFlag")]
			public string DirVertCmplActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "crossLongTracCmplActiveFlag")]
			public string CrossLongTracCmplActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "crossLongBrakCmplActiveFlag")]
			public string CrossLongBrakCmplActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "crossLatCmplActiveFlag")]
			public string CrossLatCmplActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "crossAlignCmplActiveFlag")]
			public string CrossAlignCmplActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "crossVertCmplActiveFlag")]
			public string CrossVertCmplActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "Direct_ToeFx_scaleFactor")]
			public string Direct_ToeFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_ToeFy_scaleFactor")]
			public string Direct_ToeFy_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_ToeMz_scaleFactor")]
			public string Direct_ToeMz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_ToeWheCtrFx_scaleFactor")]
			public string Direct_ToeWheCtrFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_ToeFz_scaleFactor")]
			public string Direct_ToeFz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_CamberFx_scaleFactor")]
			public string Direct_CamberFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_CamberFy_scaleFactor")]
			public string Direct_CamberFy_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_CamberMz_scaleFactor")]
			public string Direct_CamberMz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_CamberWheCtrFx_scaleFactor")]
			public string Direct_CamberWheCtrFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_CamberFz_scaleFactor")]
			public string Direct_CamberFz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_SvaFx_scaleFactor")]
			public string Direct_SvaFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_SvaFy_scaleFactor")]
			public string Direct_SvaFy_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_SvaMz_scaleFactor")]
			public string Direct_SvaMz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_SvaWheCtrFx_scaleFactor")]
			public string Direct_SvaWheCtrFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_SvaFz_scaleFactor")]
			public string Direct_SvaFz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_TrackFx_scaleFactor")]
			public string Direct_TrackFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_TrackFy_scaleFactor")]
			public string Direct_TrackFy_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_TrackMz_scaleFactor")]
			public string Direct_TrackMz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_TrackWheCtrFx_scaleFactor")]
			public string Direct_TrackWheCtrFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_TrackFz_scaleFactor")]
			public string Direct_TrackFz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_BaseFx_scaleFactor")]
			public string Direct_BaseFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_BaseFy_scaleFactor")]
			public string Direct_BaseFy_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_BaseMz_scaleFactor")]
			public string Direct_BaseMz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_BaseWheCtrFx_scaleFactor")]
			public string Direct_BaseWheCtrFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Direct_BaseFz_scaleFactor")]
			public string Direct_BaseFz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_ToeFx_scaleFactor")]
			public string Cross_ToeFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_ToeFy_scaleFactor")]
			public string Cross_ToeFy_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_ToeMz_scaleFactor")]
			public string Cross_ToeMz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_ToeWheCtrFx_scaleFactor")]
			public string Cross_ToeWheCtrFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_ToeFz_scaleFactor")]
			public string Cross_ToeFz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_CamberFx_scaleFactor")]
			public string Cross_CamberFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_CamberFy_scaleFactor")]
			public string Cross_CamberFy_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_CamberMz_scaleFactor")]
			public string Cross_CamberMz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_CamberWheCtrFx_scaleFactor")]
			public string Cross_CamberWheCtrFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_CamberFz_scaleFactor")]
			public string Cross_CamberFz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_SvaFx_scaleFactor")]
			public string Cross_SvaFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_SvaFy_scaleFactor")]
			public string Cross_SvaFy_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_SvaMz_scaleFactor")]
			public string Cross_SvaMz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_SvaWheCtrFx_scaleFactor")]
			public string Cross_SvaWheCtrFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_SvaFz_scaleFactor")]
			public string Cross_SvaFz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_TrackFx_scaleFactor")]
			public string Cross_TrackFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_TrackFy_scaleFactor")]
			public string Cross_TrackFy_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_TrackMz_scaleFactor")]
			public string Cross_TrackMz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_TrackWheCtrFx_scaleFactor")]
			public string Cross_TrackWheCtrFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_TrackFz_scaleFactor")]
			public string Cross_TrackFz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_BaseFx_scaleFactor")]
			public string Cross_BaseFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_BaseFy_scaleFactor")]
			public string Cross_BaseFy_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_BaseMz_scaleFactor")]
			public string Cross_BaseMz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_BaseWheCtrFx_scaleFactor")]
			public string Cross_BaseWheCtrFx_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Cross_BaseFz_scaleFactor")]
			public string Cross_BaseFz_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "SideViewAngle_scaleFactor")]
			public string SideViewAngle_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Camber_scaleFactor")]
			public string Camber_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Toe_scaleFactor")]
			public string Toe_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Base_scaleFactor")]
			public string Base_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "Track_scaleFactor")]
			public string Track_scaleFactor { get; set; }
		}

		[XmlRoot(ElementName = "CRTCompliance", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTCompliance
		{
			[XmlElement(ElementName = "CRTSuspensionData", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTSuspensionData> CRTSuspensionData { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "auxConstantWheelTravel")]
			public string AuxConstantWheelTravel { get; set; }
			[XmlAttribute(AttributeName = "auxConstantWheelTravelFlag")]
			public string AuxConstantWheelTravelFlag { get; set; }
		}

		[XmlRoot(ElementName = "CRTCompliancePair", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTCompliancePair
		{
			[XmlElement(ElementName = "CRTCompliance", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTCompliance> CRTCompliance { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "symmetry")]
			public string Symmetry { get; set; }
		}

		[XmlRoot(ElementName = "CRTAuxiliaryRollStiffness", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTAuxiliaryRollStiffness
		{
			[XmlElement(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline3d> Spline3d { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "method")]
			public string Method { get; set; }
			[XmlAttribute(AttributeName = "constant")]
			public string Constant { get; set; }
			[XmlAttribute(AttributeName = "unit")]
			public string Unit { get; set; }
			[XmlAttribute(AttributeName = "scaleFactor")]
			public string ScaleFactor { get; set; }
		}

		[XmlRoot(ElementName = "CRTAuxiliaryTranslationalDOF", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTAuxiliaryTranslationalDOF
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "tFNumCoeff0")]
			public string TFNumCoeff0 { get; set; }
			[XmlAttribute(AttributeName = "tFNumCoeff1")]
			public string TFNumCoeff1 { get; set; }
			[XmlAttribute(AttributeName = "tFNumCoeff2")]
			public string TFNumCoeff2 { get; set; }
			[XmlAttribute(AttributeName = "tFNumCoeff3")]
			public string TFNumCoeff3 { get; set; }
			[XmlAttribute(AttributeName = "tFNumCoeff4")]
			public string TFNumCoeff4 { get; set; }
			[XmlAttribute(AttributeName = "tFDenCoeff0")]
			public string TFDenCoeff0 { get; set; }
			[XmlAttribute(AttributeName = "tFDenCoeff1")]
			public string TFDenCoeff1 { get; set; }
			[XmlAttribute(AttributeName = "tFDenCoeff2")]
			public string TFDenCoeff2 { get; set; }
			[XmlAttribute(AttributeName = "tFDenCoeff3")]
			public string TFDenCoeff3 { get; set; }
			[XmlAttribute(AttributeName = "tFDenCoeff4")]
			public string TFDenCoeff4 { get; set; }
			[XmlAttribute(AttributeName = "tFOrder")]
			public string TFOrder { get; set; }
			[XmlAttribute(AttributeName = "lowPassCutoffFrequency")]
			public string LowPassCutoffFrequency { get; set; }
			[XmlAttribute(AttributeName = "mass")]
			public string Mass { get; set; }
			[XmlAttribute(AttributeName = "dampingMode")]
			public string DampingMode { get; set; }
			[XmlAttribute(AttributeName = "damping")]
			public string Damping { get; set; }
			[XmlAttribute(AttributeName = "dampingRatio")]
			public string DampingRatio { get; set; }
			[XmlAttribute(AttributeName = "degreeOfFreedom")]
			public string DegreeOfFreedom { get; set; }
			[XmlAttribute(AttributeName = "modelType")]
			public string ModelType { get; set; }
			[XmlAttribute(AttributeName = "excitationMode")]
			public string ExcitationMode { get; set; }
		}

		[XmlRoot(ElementName = "CRTAuxiliaryTranslationalDOFPair", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTAuxiliaryTranslationalDOFPair
		{
			[XmlElement(ElementName = "CRTAuxiliaryTranslationalDOF", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTAuxiliaryTranslationalDOF> CRTAuxiliaryTranslationalDOF { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "symmetry")]
			public string Symmetry { get; set; }
		}

		[XmlRoot(ElementName = "Comment", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class Comment
		{
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlText]
			public string Text { get; set; }
		}

		[XmlRoot(ElementName = "TireContext", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class TireContext
		{
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "propertyURI")]
			public string PropertyURI { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "context")]
			public string Context { get; set; }
			[XmlAttribute(AttributeName = "offset")]
			public string Offset { get; set; }
			[XmlAttribute(AttributeName = "lateralForceScale")]
			public string LateralForceScale { get; set; }
			[XmlAttribute(AttributeName = "overturningMomentScale")]
			public string OverturningMomentScale { get; set; }
			[XmlAttribute(AttributeName = "aligningTorqueScale")]
			public string AligningTorqueScale { get; set; }
			[XmlAttribute(AttributeName = "slipAngleSurfCorrFactor")]
			public string SlipAngleSurfCorrFactor { get; set; }
			[XmlAttribute(AttributeName = "forceSurfCorrFactor")]
			public string ForceSurfCorrFactor { get; set; }
			[XmlAttribute(AttributeName = "frictionCoeff")]
			public string FrictionCoeff { get; set; }
			[XmlAttribute(AttributeName = "rollingRadiusOffset")]
			public string RollingRadiusOffset { get; set; }
			[XmlAttribute(AttributeName = "plysteerLateralForce")]
			public string PlysteerLateralForce { get; set; }
			[XmlAttribute(AttributeName = "conicityLateralForce")]
			public string ConicityLateralForce { get; set; }
			[XmlAttribute(AttributeName = "plysteerAligningTorque")]
			public string PlysteerAligningTorque { get; set; }
			[XmlAttribute(AttributeName = "conicityAligningTorque")]
			public string ConicityAligningTorque { get; set; }
			[XmlAttribute(AttributeName = "cmOffset")]
			public string CmOffset { get; set; }
			[XmlAttribute(AttributeName = "wheelCenterOffset")]
			public string WheelCenterOffset { get; set; }
			[XmlAttribute(AttributeName = "contactType")]
			public string ContactType { get; set; }
			[XmlAttribute(AttributeName = "useMode")]
			public string UseMode { get; set; }
		}

		[XmlRoot(ElementName = "Tire", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class Tire
		{
			[XmlElement(ElementName = "TireContext", Namespace = "http://www.mscsoftware.com/:vfc")]
			public TireContext TireContext { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
		}

		[XmlRoot(ElementName = "Part", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class Part
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "location")]
			public string Location { get; set; }
			[XmlAttribute(AttributeName = "cm_location")]
			public string Cm_location { get; set; }
			[XmlAttribute(AttributeName = "im_location")]
			public string Im_location { get; set; }
			[XmlAttribute(AttributeName = "part_num")]
			public string Part_num { get; set; }
			[XmlAttribute(AttributeName = "mass")]
			public string Mass { get; set; }
			[XmlAttribute(AttributeName = "ixx")]
			public string Ixx { get; set; }
			[XmlAttribute(AttributeName = "iyy")]
			public string Iyy { get; set; }
			[XmlAttribute(AttributeName = "izz")]
			public string Izz { get; set; }
			[XmlAttribute(AttributeName = "ixy")]
			public string Ixy { get; set; }
			[XmlAttribute(AttributeName = "ixz")]
			public string Ixz { get; set; }
			[XmlAttribute(AttributeName = "iyz")]
			public string Iyz { get; set; }
			[XmlAttribute(AttributeName = "use_offdiagonal_terms")]
			public string Use_offdiagonal_terms { get; set; }
			[XmlAttribute(AttributeName = "default_cg")]
			public string Default_cg { get; set; }
			[XmlAttribute(AttributeName = "global_cg")]
			public string Global_cg { get; set; }
			[XmlAttribute(AttributeName = "user_sprung")]
			public string User_sprung { get; set; }
			[XmlAttribute(AttributeName = "percent_sprung")]
			public string Percent_sprung { get; set; }
		}

		[XmlRoot(ElementName = "WheelGraphics", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class WheelGraphics
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "bulgeRatio")]
			public string BulgeRatio { get; set; }
			[XmlAttribute(AttributeName = "wheelWidth")]
			public string WheelWidth { get; set; }
		}

		[XmlRoot(ElementName = "CRTWheel", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTWheel
		{
			[XmlElement(ElementName = "Tire", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Tire Tire { get; set; }
			[XmlElement(ElementName = "Part", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Part Part { get; set; }
			[XmlElement(ElementName = "WheelGraphics", Namespace = "http://www.mscsoftware.com/:vfc")]
			public WheelGraphics WheelGraphics { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "spinInertia")]
			public string SpinInertia { get; set; }
			[XmlAttribute(AttributeName = "unsprungMass")]
			public string UnsprungMass { get; set; }
			[XmlAttribute(AttributeName = "wheelCenterHeight")]
			public string WheelCenterHeight { get; set; }
			[XmlAttribute(AttributeName = "ixx")]
			public string Ixx { get; set; }
			[XmlAttribute(AttributeName = "iyy")]
			public string Iyy { get; set; }
			[XmlAttribute(AttributeName = "izz")]
			public string Izz { get; set; }
			[XmlAttribute(AttributeName = "longitudinalDynamicsFlag")]
			public string LongitudinalDynamicsFlag { get; set; }
			[XmlAttribute(AttributeName = "longitudinalDynamicsMass")]
			public string LongitudinalDynamicsMass { get; set; }
			[XmlAttribute(AttributeName = "longitudinalDynamicsCutoffFrequency")]
			public string LongitudinalDynamicsCutoffFrequency { get; set; }
			[XmlAttribute(AttributeName = "longitudinalDynamicsDamping")]
			public string LongitudinalDynamicsDamping { get; set; }
			[XmlAttribute(AttributeName = "Mode")]
			public string Mode { get; set; }
		}

		[XmlRoot(ElementName = "CRTWheelPair", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTWheelPair
		{
			[XmlElement(ElementName = "CRTWheel", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTWheel> CRTWheel { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "symmetry")]
			public string Symmetry { get; set; }
		}

		[XmlRoot(ElementName = "Spline2d", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class Spline2d
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "interpolation_method")]
			public string Interpolation_method { get; set; }
			[XmlAttribute(AttributeName = "xLabel")]
			public string XLabel { get; set; }
			[XmlAttribute(AttributeName = "yLabel")]
			public string YLabel { get; set; }
			[XmlAttribute(AttributeName = "xUnit")]
			public string XUnit { get; set; }
			[XmlAttribute(AttributeName = "yUnit")]
			public string YUnit { get; set; }
			[XmlAttribute(AttributeName = "datablock")]
			public string Datablock { get; set; }
			[XmlText]
			public string Text { get; set; }
			[XmlElement(ElementName = "Comment", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Comment Comment { get; set; }
		}

		[XmlRoot(ElementName = "CRTSteeringSystem", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTSteeringSystem
		{
			[XmlElement(ElementName = "CRTSuspensionData", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTSuspensionData CRTSuspensionData { get; set; }
			[XmlElement(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline3d> Spline3d { get; set; }
			[XmlElement(ElementName = "Spline2d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline2d> Spline2d { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "nominalSteeringGearRatio")]
			public string NominalSteeringGearRatio { get; set; }
			[XmlAttribute(AttributeName = "kingpinLeftFront")]
			public string KingpinLeftFront { get; set; }
			[XmlAttribute(AttributeName = "kingpinRightFront")]
			public string KingpinRightFront { get; set; }
			[XmlAttribute(AttributeName = "arbitraryLeftPoint")]
			public string ArbitraryLeftPoint { get; set; }
			[XmlAttribute(AttributeName = "arbitraryRightPoint")]
			public string ArbitraryRightPoint { get; set; }
			[XmlAttribute(AttributeName = "casterAngleLeftFront")]
			public string CasterAngleLeftFront { get; set; }
			[XmlAttribute(AttributeName = "casterAngleRightFront")]
			public string CasterAngleRightFront { get; set; }
			[XmlAttribute(AttributeName = "complianceCutOff")]
			public string ComplianceCutOff { get; set; }
			[XmlAttribute(AttributeName = "method")]
			public string Method { get; set; }
			[XmlAttribute(AttributeName = "steeringInertia")]
			public string SteeringInertia { get; set; }
			[XmlAttribute(AttributeName = "steeringDamping")]
			public string SteeringDamping { get; set; }
			[XmlAttribute(AttributeName = "steeringEspFrictionLimitMax")]
			public string SteeringEspFrictionLimitMax { get; set; }
			[XmlAttribute(AttributeName = "steeringColumnMethod")]
			public string SteeringColumnMethod { get; set; }
			[XmlAttribute(AttributeName = "tierodOuterLeftPoint")]
			public string TierodOuterLeftPoint { get; set; }
			[XmlAttribute(AttributeName = "tierodInnerLeftPoint")]
			public string TierodInnerLeftPoint { get; set; }
			[XmlAttribute(AttributeName = "tierodOuterRightPoint")]
			public string TierodOuterRightPoint { get; set; }
			[XmlAttribute(AttributeName = "tierodInnerRightPoint")]
			public string TierodInnerRightPoint { get; set; }
			[XmlAttribute(AttributeName = "steeringWheelInputActive")]
			public string SteeringWheelInputActive { get; set; }
			[XmlAttribute(AttributeName = "variableSteerAxisActive")]
			public string VariableSteerAxisActive { get; set; }
			[XmlAttribute(AttributeName = "wheelLocSteerDepActive")]
			public string WheelLocSteerDepActive { get; set; }
			[XmlAttribute(AttributeName = "tierodKinematicsActive")]
			public string TierodKinematicsActive { get; set; }
			[XmlAttribute(AttributeName = "steeringFeedbackMapsActive")]
			public string SteeringFeedbackMapsActive { get; set; }
		}

		[XmlRoot(ElementName = "CRTRotationalFriction", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTRotationalFriction
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "stiffness")]
			public string Stiffness { get; set; }
			[XmlAttribute(AttributeName = "minTorque")]
			public string MinTorque { get; set; }
			[XmlAttribute(AttributeName = "maxTorque")]
			public string MaxTorque { get; set; }
			[XmlAttribute(AttributeName = "maxwellActiveFlag")]
			public string MaxwellActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "maxwellStiffness")]
			public string MaxwellStiffness { get; set; }
			[XmlAttribute(AttributeName = "maxwellDamping")]
			public string MaxwellDamping { get; set; }
			[XmlAttribute(AttributeName = "maxwellMaxTorque")]
			public string MaxwellMaxTorque { get; set; }
			[XmlAttribute(AttributeName = "coulombActiveFlag")]
			public string CoulombActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "coulombMuS")]
			public string CoulombMuS { get; set; }
			[XmlAttribute(AttributeName = "coulombMuD")]
			public string CoulombMuD { get; set; }
			[XmlAttribute(AttributeName = "coulombMaxTorque")]
			public string CoulombMaxTorque { get; set; }
			[XmlAttribute(AttributeName = "coulombTransitionVelocity")]
			public string CoulombTransitionVelocity { get; set; }
		}

		[XmlRoot(ElementName = "CRTTranslationalFriction", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTTranslationalFriction
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "stiffness")]
			public string Stiffness { get; set; }
			[XmlAttribute(AttributeName = "maxForce")]
			public string MaxForce { get; set; }
			[XmlAttribute(AttributeName = "minForce")]
			public string MinForce { get; set; }
			[XmlAttribute(AttributeName = "maxwellActiveFlag")]
			public string MaxwellActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "maxwellStiffness")]
			public string MaxwellStiffness { get; set; }
			[XmlAttribute(AttributeName = "maxwellDamping")]
			public string MaxwellDamping { get; set; }
			[XmlAttribute(AttributeName = "maxwellMaxForce")]
			public string MaxwellMaxForce { get; set; }
			[XmlAttribute(AttributeName = "coulombActiveFlag")]
			public string CoulombActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "coulombMuS")]
			public string CoulombMuS { get; set; }
			[XmlAttribute(AttributeName = "coulombMuD")]
			public string CoulombMuD { get; set; }
			[XmlAttribute(AttributeName = "coulombMaxForce")]
			public string CoulombMaxForce { get; set; }
			[XmlAttribute(AttributeName = "coulombTransitionVelocity")]
			public string CoulombTransitionVelocity { get; set; }
		}

		[XmlRoot(ElementName = "CRTMechanicalSteering", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTMechanicalSteering
		{
			[XmlElement(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Spline3d Spline3d { get; set; }
			[XmlElement(ElementName = "CRTRotationalFriction", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTRotationalFriction> CRTRotationalFriction { get; set; }
			[XmlElement(ElementName = "CRTTranslationalFriction", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTTranslationalFriction CRTTranslationalFriction { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "columnALocation")]
			public string ColumnALocation { get; set; }
			[XmlAttribute(AttributeName = "columnBLocation")]
			public string ColumnBLocation { get; set; }
			[XmlAttribute(AttributeName = "columnCLocation")]
			public string ColumnCLocation { get; set; }
			[XmlAttribute(AttributeName = "columnDLocation")]
			public string ColumnDLocation { get; set; }
			[XmlAttribute(AttributeName = "columnELocation")]
			public string ColumnELocation { get; set; }
			[XmlAttribute(AttributeName = "steeringColumnConfiguration")]
			public string SteeringColumnConfiguration { get; set; }
			[XmlAttribute(AttributeName = "columnHookMountingAngle")]
			public string ColumnHookMountingAngle { get; set; }
			[XmlAttribute(AttributeName = "columnHookRelativeAngle")]
			public string ColumnHookRelativeAngle { get; set; }
			[XmlAttribute(AttributeName = "columnExtraHookRelativeAngle")]
			public string ColumnExtraHookRelativeAngle { get; set; }
			[XmlAttribute(AttributeName = "steeringWheelInertia")]
			public string SteeringWheelInertia { get; set; }
			[XmlAttribute(AttributeName = "columnInertia")]
			public string ColumnInertia { get; set; }
			[XmlAttribute(AttributeName = "intermediateColumnInertia")]
			public string IntermediateColumnInertia { get; set; }
			[XmlAttribute(AttributeName = "intermediateExtraColumnInertia")]
			public string IntermediateExtraColumnInertia { get; set; }
			[XmlAttribute(AttributeName = "lowerColumnInertia")]
			public string LowerColumnInertia { get; set; }
			[XmlAttribute(AttributeName = "torsionBarStiffness")]
			public string TorsionBarStiffness { get; set; }
			[XmlAttribute(AttributeName = "torsionBarDamping")]
			public string TorsionBarDamping { get; set; }
			[XmlAttribute(AttributeName = "torsionBarAttachment")]
			public string TorsionBarAttachment { get; set; }
			[XmlAttribute(AttributeName = "torsionBarTwistLimit")]
			public string TorsionBarTwistLimit { get; set; }
			[XmlAttribute(AttributeName = "torsionBarLimitStiffness")]
			public string TorsionBarLimitStiffness { get; set; }
			[XmlAttribute(AttributeName = "meshStiffness")]
			public string MeshStiffness { get; set; }
			[XmlAttribute(AttributeName = "hardyDiskStiffness")]
			public string HardyDiskStiffness { get; set; }
			[XmlAttribute(AttributeName = "steeringRatioMethod")]
			public string SteeringRatioMethod { get; set; }
			[XmlAttribute(AttributeName = "rackToPinionRatio")]
			public string RackToPinionRatio { get; set; }
			[XmlAttribute(AttributeName = "rackToPinionRatio_scaleFactor")]
			public string RackToPinionRatio_scaleFactor { get; set; }
			[XmlAttribute(AttributeName = "rackMaxTravel")]
			public string RackMaxTravel { get; set; }
			[XmlAttribute(AttributeName = "rackMass")]
			public string RackMass { get; set; }
			[XmlAttribute(AttributeName = "rackDamping")]
			public string RackDamping { get; set; }
			[XmlAttribute(AttributeName = "upperColumnStiffness")]
			public string UpperColumnStiffness { get; set; }
			[XmlAttribute(AttributeName = "lowerColumnStiffness")]
			public string LowerColumnStiffness { get; set; }
			[XmlAttribute(AttributeName = "rigidUpperColumnFlag")]
			public string RigidUpperColumnFlag { get; set; }
			[XmlAttribute(AttributeName = "rigidLowerColumnFlag")]
			public string RigidLowerColumnFlag { get; set; }
			[XmlAttribute(AttributeName = "rigidHardyDiskFlag")]
			public string RigidHardyDiskFlag { get; set; }
			[XmlAttribute(AttributeName = "rigidMeshFlag")]
			public string RigidMeshFlag { get; set; }
			[XmlAttribute(AttributeName = "upperColumnDamping")]
			public string UpperColumnDamping { get; set; }
			[XmlAttribute(AttributeName = "lowerColumnDamping")]
			public string LowerColumnDamping { get; set; }
		}

		[XmlRoot(ElementName = "CRTAdvancedSteering", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTAdvancedSteering
		{
			[XmlElement(ElementName = "CRTMechanicalSteering", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTMechanicalSteering CRTMechanicalSteering { get; set; }
			[XmlElement(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline3d> Spline3d { get; set; }
			[XmlElement(ElementName = "CRTRotationalFriction", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTRotationalFriction CRTRotationalFriction { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "useInternal")]
			public string UseInternal { get; set; }
			[XmlAttribute(AttributeName = "pluginLibrary")]
			public string PluginLibrary { get; set; }
			[XmlAttribute(AttributeName = "solverIntegrationStep")]
			public string SolverIntegrationStep { get; set; }
			[XmlAttribute(AttributeName = "solverIntegratorType")]
			public string SolverIntegratorType { get; set; }
			[XmlAttribute(AttributeName = "steeringPidKp")]
			public string SteeringPidKp { get; set; }
			[XmlAttribute(AttributeName = "steeringPidKi")]
			public string SteeringPidKi { get; set; }
			[XmlAttribute(AttributeName = "steeringPidKd")]
			public string SteeringPidKd { get; set; }
			[XmlAttribute(AttributeName = "steeringAssistType")]
			public string SteeringAssistType { get; set; }
			[XmlAttribute(AttributeName = "steeringAssistActive")]
			public string SteeringAssistActive { get; set; }
			[XmlAttribute(AttributeName = "eMotorKt")]
			public string EMotorKt { get; set; }
			[XmlAttribute(AttributeName = "eMotorColumnRatio")]
			public string EMotorColumnRatio { get; set; }
			[XmlAttribute(AttributeName = "eMotorPinionRatio")]
			public string EMotorPinionRatio { get; set; }
			[XmlAttribute(AttributeName = "eMotorRackRatio")]
			public string EMotorRackRatio { get; set; }
			[XmlAttribute(AttributeName = "eMotorTau")]
			public string EMotorTau { get; set; }
			[XmlAttribute(AttributeName = "eServoGearFlag")]
			public string EServoGearFlag { get; set; }
			[XmlAttribute(AttributeName = "eServoGearRigidFlag")]
			public string EServoGearRigidFlag { get; set; }
			[XmlAttribute(AttributeName = "eServoGearInertia")]
			public string EServoGearInertia { get; set; }
			[XmlAttribute(AttributeName = "eServoGearTorsionStiffness")]
			public string EServoGearTorsionStiffness { get; set; }
			[XmlAttribute(AttributeName = "eServoGearTorsionDamping")]
			public string EServoGearTorsionDamping { get; set; }
			[XmlAttribute(AttributeName = "eServoGearEfficiency")]
			public string EServoGearEfficiency { get; set; }
			[XmlAttribute(AttributeName = "hPistonArea")]
			public string HPistonArea { get; set; }
			[XmlAttribute(AttributeName = "hDensity")]
			public string HDensity { get; set; }
			[XmlAttribute(AttributeName = "hTau")]
			public string HTau { get; set; }
			[XmlAttribute(AttributeName = "hBulkCoefficient")]
			public string HBulkCoefficient { get; set; }
			[XmlAttribute(AttributeName = "hPistonVolume")]
			public string HPistonVolume { get; set; }
			[XmlAttribute(AttributeName = "hOrificeArea")]
			public string HOrificeArea { get; set; }
			[XmlAttribute(AttributeName = "hOrificeCoefficient")]
			public string HOrificeCoefficient { get; set; }
			[XmlAttribute(AttributeName = "steeringWheelLowPassFrequency")]
			public string SteeringWheelLowPassFrequency { get; set; }
			[XmlAttribute(AttributeName = "steeringWheelModelError")]
			public string SteeringWheelModelError { get; set; }
			[XmlAttribute(AttributeName = "steeringWheelMeasureError")]
			public string SteeringWheelMeasureError { get; set; }
			[XmlAttribute(AttributeName = "driverHandComplianceFlag")]
			public string DriverHandComplianceFlag { get; set; }
			[XmlAttribute(AttributeName = "driverHandInertia")]
			public string DriverHandInertia { get; set; }
			[XmlAttribute(AttributeName = "driverHandTorsionStiffness")]
			public string DriverHandTorsionStiffness { get; set; }
			[XmlAttribute(AttributeName = "driverHandTorsionDamping")]
			public string DriverHandTorsionDamping { get; set; }
		}

		[XmlRoot(ElementName = "CRTKinematicsData", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTKinematicsData
		{
			[XmlElement(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline3d> Spline3d { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "kingpinMomentActiveFlag")]
			public string KingpinMomentActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "useOutboundPointSpline")]
			public string UseOutboundPointSpline { get; set; }
			[XmlAttribute(AttributeName = "pointOnUpright")]
			public string PointOnUpright { get; set; }
			[XmlAttribute(AttributeName = "pointOnChassis")]
			public string PointOnChassis { get; set; }
		}

		[XmlRoot(ElementName = "CRTRamAir", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTRamAir
		{
			[XmlElement(ElementName = "Spline", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Spline Spline { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "referenceAirDensity")]
			public string ReferenceAirDensity { get; set; }
			[XmlAttribute(AttributeName = "ambientPressure")]
			public string AmbientPressure { get; set; }
			[XmlAttribute(AttributeName = "ambientTemperature")]
			public string AmbientTemperature { get; set; }
		}

		[XmlRoot(ElementName = "CRTFuelConsumption", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTFuelConsumption
		{
			[XmlElement(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Spline3d Spline3d { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "fuelDensity")]
			public string FuelDensity { get; set; }
			[XmlAttribute(AttributeName = "engineVolume")]
			public string EngineVolume { get; set; }
			[XmlAttribute(AttributeName = "activeOnBraking")]
			public string ActiveOnBraking { get; set; }
		}

		[XmlRoot(ElementName = "CRTInternalCombustionEngine", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTInternalCombustionEngine
		{
			[XmlElement(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline3d> Spline3d { get; set; }
			[XmlElement(ElementName = "Spline", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline> Spline { get; set; }
			[XmlElement(ElementName = "CRTRamAir", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTRamAir CRTRamAir { get; set; }
			[XmlElement(ElementName = "CRTFuelConsumption", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTFuelConsumption CRTFuelConsumption { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "method")]
			public string Method { get; set; }
			[XmlAttribute(AttributeName = "torqueMapFileFlag")]
			public string TorqueMapFileFlag { get; set; }
			[XmlAttribute(AttributeName = "torqueMapFile")]
			public string TorqueMapFile { get; set; }
			[XmlAttribute(AttributeName = "eMotorTorqueMapFileFlag")]
			public string EMotorTorqueMapFileFlag { get; set; }
			[XmlAttribute(AttributeName = "inertia")]
			public string Inertia { get; set; }
			[XmlAttribute(AttributeName = "stallRPM")]
			public string StallRPM { get; set; }
			[XmlAttribute(AttributeName = "idleRPM")]
			public string IdleRPM { get; set; }
			[XmlAttribute(AttributeName = "revLimitRPM")]
			public string RevLimitRPM { get; set; }
			[XmlAttribute(AttributeName = "revLimitMapActiveFlag")]
			public string RevLimitMapActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "torqueReactionDirection")]
			public string TorqueReactionDirection { get; set; }
			[XmlAttribute(AttributeName = "simpleEngineMinimumTorque")]
			public string SimpleEngineMinimumTorque { get; set; }
			[XmlAttribute(AttributeName = "simpleEngineMaximumTorque")]
			public string SimpleEngineMaximumTorque { get; set; }
			[XmlAttribute(AttributeName = "simpleEngineMaximumPower")]
			public string SimpleEngineMaximumPower { get; set; }
			[XmlAttribute(AttributeName = "torqueOutputOption")]
			public string TorqueOutputOption { get; set; }
			[XmlAttribute(AttributeName = "simpleEngineTau")]
			public string SimpleEngineTau { get; set; }
			[XmlAttribute(AttributeName = "efficiency")]
			public string Efficiency { get; set; }
			[XmlAttribute(AttributeName = "torqueScalingFactor")]
			public string TorqueScalingFactor { get; set; }
			[XmlAttribute(AttributeName = "idleControlActiveFlag")]
			public string IdleControlActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "idleControlMaximumThrottle")]
			public string IdleControlMaximumThrottle { get; set; }
			[XmlAttribute(AttributeName = "idleControlGain")]
			public string IdleControlGain { get; set; }
			[XmlAttribute(AttributeName = "maxRPMControlActiveFlag")]
			public string MaxRPMControlActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "maxRPMControlGain")]
			public string MaxRPMControlGain { get; set; }
			[XmlAttribute(AttributeName = "transmissionRatio")]
			public string TransmissionRatio { get; set; }
			[XmlAttribute(AttributeName = "tractionControlActiveFlag")]
			public string TractionControlActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "tractionControlGain")]
			public string TractionControlGain { get; set; }
			[XmlAttribute(AttributeName = "tractionControlThreshold")]
			public string TractionControlThreshold { get; set; }
			[XmlAttribute(AttributeName = "regenerativeBrakingFactor")]
			public string RegenerativeBrakingFactor { get; set; }
			[XmlAttribute(AttributeName = "longitudinalVelocityThreshold")]
			public string LongitudinalVelocityThreshold { get; set; }
			[XmlAttribute(AttributeName = "eMotorRegenerationMapFlag")]
			public string EMotorRegenerationMapFlag { get; set; }
			[XmlAttribute(AttributeName = "eMotorEfficiencyMapFlag")]
			public string EMotorEfficiencyMapFlag { get; set; }
		}

		[XmlRoot(ElementName = "CRTTorqueConverter", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTTorqueConverter
		{
			[XmlElement(ElementName = "Spline2d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline2d> Spline2d { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "capacityFactor")]
			public string CapacityFactor { get; set; }
			[XmlAttribute(AttributeName = "shiftCycleTime")]
			public string ShiftCycleTime { get; set; }
			[XmlAttribute(AttributeName = "oilDumpThreshold")]
			public string OilDumpThreshold { get; set; }
			[XmlAttribute(AttributeName = "oilDumpResidual")]
			public string OilDumpResidual { get; set; }
			[XmlAttribute(AttributeName = "throttleOff")]
			public string ThrottleOff { get; set; }
			[XmlAttribute(AttributeName = "torqueReactionDirection")]
			public string TorqueReactionDirection { get; set; }
			[XmlAttribute(AttributeName = "clutchLockUpFlag")]
			public string ClutchLockUpFlag { get; set; }
			[XmlAttribute(AttributeName = "clutchLockUpGearId")]
			public string ClutchLockUpGearId { get; set; }
			[XmlAttribute(AttributeName = "clutchLockUpSpeed")]
			public string ClutchLockUpSpeed { get; set; }
			[XmlAttribute(AttributeName = "clutchLockUpTimeDelay")]
			public string ClutchLockUpTimeDelay { get; set; }
		}

		[XmlRoot(ElementName = "CRTClutch", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTClutch
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "method")]
			public string Method { get; set; }
			[XmlAttribute(AttributeName = "inertia")]
			public string Inertia { get; set; }
			[XmlAttribute(AttributeName = "tau")]
			public string Tau { get; set; }
			[XmlAttribute(AttributeName = "capacity")]
			public string Capacity { get; set; }
			[XmlAttribute(AttributeName = "stiffness")]
			public string Stiffness { get; set; }
			[XmlAttribute(AttributeName = "damping")]
			public string Damping { get; set; }
			[XmlAttribute(AttributeName = "clutchOpen")]
			public string ClutchOpen { get; set; }
			[XmlAttribute(AttributeName = "clutchClose")]
			public string ClutchClose { get; set; }
			[XmlAttribute(AttributeName = "efficiency")]
			public string Efficiency { get; set; }
			[XmlAttribute(AttributeName = "shiftCycleTime")]
			public string ShiftCycleTime { get; set; }
			[XmlAttribute(AttributeName = "torqueReactionDirection")]
			public string TorqueReactionDirection { get; set; }
		}

		[XmlRoot(ElementName = "CRTBattery", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTBattery
		{
			[XmlElement(ElementName = "Spline2d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Spline2d Spline2d { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "type")]
			public string Type { get; set; }
			[XmlAttribute(AttributeName = "voltageMethod")]
			public string VoltageMethod { get; set; }
			[XmlAttribute(AttributeName = "paramE0")]
			public string ParamE0 { get; set; }
			[XmlAttribute(AttributeName = "paramK")]
			public string ParamK { get; set; }
			[XmlAttribute(AttributeName = "paramQ")]
			public string ParamQ { get; set; }
			[XmlAttribute(AttributeName = "paramRT")]
			public string ParamRT { get; set; }
			[XmlAttribute(AttributeName = "paramR")]
			public string ParamR { get; set; }
			[XmlAttribute(AttributeName = "SOC")]
			public string SOC { get; set; }
			[XmlAttribute(AttributeName = "paramA")]
			public string ParamA { get; set; }
			[XmlAttribute(AttributeName = "paramB")]
			public string ParamB { get; set; }
			[XmlAttribute(AttributeName = "KCSat")]
			public string KCSat { get; set; }
			[XmlAttribute(AttributeName = "maxPeakCurrent")]
			public string MaxPeakCurrent { get; set; }
		}

		[XmlRoot(ElementName = "CRTManualGearbox", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTManualGearbox
		{
			[XmlElement(ElementName = "Spline2d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline2d> Spline2d { get; set; }
			[XmlElement(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline3d> Spline3d { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "inertia")]
			public string Inertia { get; set; }
			[XmlAttribute(AttributeName = "gearShiftMethod")]
			public string GearShiftMethod { get; set; }
			[XmlAttribute(AttributeName = "inertiaMethod")]
			public string InertiaMethod { get; set; }
			[XmlAttribute(AttributeName = "upshiftRPM")]
			public string UpshiftRPM { get; set; }
			[XmlAttribute(AttributeName = "downshiftRPM")]
			public string DownshiftRPM { get; set; }
			[XmlAttribute(AttributeName = "torqueReactionDirection")]
			public string TorqueReactionDirection { get; set; }
		}

		[XmlRoot(ElementName = "CRTAutomaticTransmission", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTAutomaticTransmission
		{
			[XmlElement(ElementName = "Spline2d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline2d> Spline2d { get; set; }
			[XmlElement(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline3d> Spline3d { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "inertiaMethod")]
			public string InertiaMethod { get; set; }
			[XmlAttribute(AttributeName = "inertia")]
			public string Inertia { get; set; }
			[XmlAttribute(AttributeName = "rpmInputMethod")]
			public string RpmInputMethod { get; set; }
			[XmlAttribute(AttributeName = "gearShiftingMode")]
			public string GearShiftingMode { get; set; }
			[XmlAttribute(AttributeName = "torqueReactionDirection")]
			public string TorqueReactionDirection { get; set; }
		}

		[XmlRoot(ElementName = "Differential", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class Differential
		{
			[XmlElement(ElementName = "CRTSuspensionData", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTSuspensionData CRTSuspensionData { get; set; }
			[XmlElement(ElementName = "Spline2d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Spline2d Spline2d { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "activeFlag")]
			public string ActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "inertia")]
			public string Inertia { get; set; }
			[XmlAttribute(AttributeName = "driveRatio")]
			public string DriveRatio { get; set; }
			[XmlAttribute(AttributeName = "method")]
			public string Method { get; set; }
			[XmlAttribute(AttributeName = "LSD_C0_pos")]
			public string LSD_C0_pos { get; set; }
			[XmlAttribute(AttributeName = "LSD_C0_neg")]
			public string LSD_C0_neg { get; set; }
			[XmlAttribute(AttributeName = "LSD_C2")]
			public string LSD_C2 { get; set; }
			[XmlAttribute(AttributeName = "LSD_C3")]
			public string LSD_C3 { get; set; }
			[XmlAttribute(AttributeName = "detroitLocker")]
			public string DetroitLocker { get; set; }
			[XmlAttribute(AttributeName = "efficiency")]
			public string Efficiency { get; set; }
			[XmlAttribute(AttributeName = "tripotOuter1")]
			public string TripotOuter1 { get; set; }
			[XmlAttribute(AttributeName = "tripotInner1")]
			public string TripotInner1 { get; set; }
			[XmlAttribute(AttributeName = "tripotOuter2")]
			public string TripotOuter2 { get; set; }
			[XmlAttribute(AttributeName = "tripotInner2")]
			public string TripotInner2 { get; set; }
			[XmlAttribute(AttributeName = "shaftReactionComputation")]
			public string ShaftReactionComputation { get; set; }
			[XmlAttribute(AttributeName = "torqueReactionBody")]
			public string TorqueReactionBody { get; set; }
			[XmlAttribute(AttributeName = "frontTorqueReactionDirection")]
			public string FrontTorqueReactionDirection { get; set; }
			[XmlAttribute(AttributeName = "rearTorqueReactionDirection")]
			public string RearTorqueReactionDirection { get; set; }
		}

		[XmlRoot(ElementName = "CRTMotor", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTMotor
		{
			[XmlElement(ElementName = "Spline3d", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline3d> Spline3d { get; set; }
			[XmlElement(ElementName = "Spline", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline> Spline { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "method")]
			public string Method { get; set; }
			[XmlAttribute(AttributeName = "torqueMapFileFlag")]
			public string TorqueMapFileFlag { get; set; }
			[XmlAttribute(AttributeName = "torqueMapFile")]
			public string TorqueMapFile { get; set; }
			[XmlAttribute(AttributeName = "eMotorTorqueMapFileFlag")]
			public string EMotorTorqueMapFileFlag { get; set; }
			[XmlAttribute(AttributeName = "inertia")]
			public string Inertia { get; set; }
			[XmlAttribute(AttributeName = "stallRPM")]
			public string StallRPM { get; set; }
			[XmlAttribute(AttributeName = "idleRPM")]
			public string IdleRPM { get; set; }
			[XmlAttribute(AttributeName = "revLimitRPM")]
			public string RevLimitRPM { get; set; }
			[XmlAttribute(AttributeName = "revLimitMapActiveFlag")]
			public string RevLimitMapActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "torqueReactionDirection")]
			public string TorqueReactionDirection { get; set; }
			[XmlAttribute(AttributeName = "simpleEngineMinimumTorque")]
			public string SimpleEngineMinimumTorque { get; set; }
			[XmlAttribute(AttributeName = "simpleEngineMaximumTorque")]
			public string SimpleEngineMaximumTorque { get; set; }
			[XmlAttribute(AttributeName = "simpleEngineMaximumPower")]
			public string SimpleEngineMaximumPower { get; set; }
			[XmlAttribute(AttributeName = "torqueOutputOption")]
			public string TorqueOutputOption { get; set; }
			[XmlAttribute(AttributeName = "simpleEngineTau")]
			public string SimpleEngineTau { get; set; }
			[XmlAttribute(AttributeName = "efficiency")]
			public string Efficiency { get; set; }
			[XmlAttribute(AttributeName = "torqueScalingFactor")]
			public string TorqueScalingFactor { get; set; }
			[XmlAttribute(AttributeName = "idleControlActiveFlag")]
			public string IdleControlActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "idleControlMaximumThrottle")]
			public string IdleControlMaximumThrottle { get; set; }
			[XmlAttribute(AttributeName = "idleControlGain")]
			public string IdleControlGain { get; set; }
			[XmlAttribute(AttributeName = "maxRPMControlActiveFlag")]
			public string MaxRPMControlActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "maxRPMControlGain")]
			public string MaxRPMControlGain { get; set; }
			[XmlAttribute(AttributeName = "transmissionRatio")]
			public string TransmissionRatio { get; set; }
			[XmlAttribute(AttributeName = "tractionControlActiveFlag")]
			public string TractionControlActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "tractionControlGain")]
			public string TractionControlGain { get; set; }
			[XmlAttribute(AttributeName = "tractionControlThreshold")]
			public string TractionControlThreshold { get; set; }
			[XmlAttribute(AttributeName = "regenerativeBrakingFactor")]
			public string RegenerativeBrakingFactor { get; set; }
			[XmlAttribute(AttributeName = "longitudinalVelocityThreshold")]
			public string LongitudinalVelocityThreshold { get; set; }
			[XmlAttribute(AttributeName = "eMotorRegenerationMapFlag")]
			public string EMotorRegenerationMapFlag { get; set; }
			[XmlAttribute(AttributeName = "eMotorEfficiencyMapFlag")]
			public string EMotorEfficiencyMapFlag { get; set; }
		}

		[XmlRoot(ElementName = "CRTDriveline", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class CRTDriveline
		{
			[XmlElement(ElementName = "CRTInternalCombustionEngine", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTInternalCombustionEngine CRTInternalCombustionEngine { get; set; }
			[XmlElement(ElementName = "CRTTorqueConverter", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTTorqueConverter CRTTorqueConverter { get; set; }
			[XmlElement(ElementName = "CRTClutch", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTClutch CRTClutch { get; set; }
			[XmlElement(ElementName = "CRTBattery", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTBattery CRTBattery { get; set; }
			[XmlElement(ElementName = "CRTManualGearbox", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTManualGearbox CRTManualGearbox { get; set; }
			[XmlElement(ElementName = "CRTAutomaticTransmission", Namespace = "http://www.mscsoftware.com/:vfc")]
			public CRTAutomaticTransmission CRTAutomaticTransmission { get; set; }
			[XmlElement(ElementName = "Differential", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Differential> Differential { get; set; }
			[XmlElement(ElementName = "CRTMotor", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<CRTMotor> CRTMotor { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "intComEngineActive")]
			public string IntComEngineActive { get; set; }
			[XmlAttribute(AttributeName = "topDrvMotorActive")]
			public string TopDrvMotorActive { get; set; }
			[XmlAttribute(AttributeName = "centralDrvMotorActive")]
			public string CentralDrvMotorActive { get; set; }
			[XmlAttribute(AttributeName = "frontDrvMotorActive")]
			public string FrontDrvMotorActive { get; set; }
			[XmlAttribute(AttributeName = "rearDrvMotorActive")]
			public string RearDrvMotorActive { get; set; }
			[XmlAttribute(AttributeName = "fLWheelMotorActive")]
			public string FLWheelMotorActive { get; set; }
			[XmlAttribute(AttributeName = "fRWheelMotorActive")]
			public string FRWheelMotorActive { get; set; }
			[XmlAttribute(AttributeName = "rLWheelMotorActive")]
			public string RLWheelMotorActive { get; set; }
			[XmlAttribute(AttributeName = "rRWheelMotorActive")]
			public string RRWheelMotorActive { get; set; }
			[XmlAttribute(AttributeName = "driveMethod")]
			public string DriveMethod { get; set; }
			[XmlAttribute(AttributeName = "driveTorqueFrontBias")]
			public string DriveTorqueFrontBias { get; set; }
			[XmlAttribute(AttributeName = "clutchTCConfig")]
			public string ClutchTCConfig { get; set; }
			[XmlAttribute(AttributeName = "gearboxConfig")]
			public string GearboxConfig { get; set; }
		}

		[XmlRoot(ElementName = "FloatParameter", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class FloatParameter
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName = "unit")]
			public string Unit { get; set; }
			[XmlElement(ElementName = "Comment", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Comment Comment { get; set; }
		}

		[XmlRoot(ElementName = "FloatParameterPair", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class FloatParameterPair
		{
			[XmlElement(ElementName = "FloatParameter", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<FloatParameter> FloatParameter { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "symmetry")]
			public string Symmetry { get; set; }
		}

		[XmlRoot(ElementName = "IntParameter", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class IntParameter
		{
			[XmlElement(ElementName = "Comment", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Comment Comment { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
			[XmlElement(ElementName = "ParameterTree", Namespace = "http://www.mscsoftware.com/:vfc")]
			public ParameterTree ParameterTree { get; set; }
		}

		[XmlRoot(ElementName = "SpringProperties", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class SpringProperties
		{
			[XmlElement(ElementName = "Spline", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline> Spline { get; set; }
			[XmlElement(ElementName = "FloatParameter", Namespace = "http://www.mscsoftware.com/:vfc")]
			public FloatParameter FloatParameter { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "diameter")]
			public string Diameter { get; set; }
			[XmlAttribute(AttributeName = "coils")]
			public string Coils { get; set; }
			[XmlAttribute(AttributeName = "rate")]
			public string Rate { get; set; }
			[XmlAttribute(AttributeName = "freeLength")]
			public string FreeLength { get; set; }
			[XmlAttribute(AttributeName = "method")]
			public string Method { get; set; }
			[XmlAttribute(AttributeName = "independentAxis")]
			public string IndependentAxis { get; set; }
		}

		[XmlRoot(ElementName = "DamperProperties", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class DamperProperties
		{
			[XmlElement(ElementName = "Spline", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Spline> Spline { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "upperDiameter")]
			public string UpperDiameter { get; set; }
			[XmlAttribute(AttributeName = "upperLength")]
			public string UpperLength { get; set; }
			[XmlAttribute(AttributeName = "lowerDiameter")]
			public string LowerDiameter { get; set; }
			[XmlAttribute(AttributeName = "lowerLength")]
			public string LowerLength { get; set; }
			[XmlAttribute(AttributeName = "rate")]
			public string Rate { get; set; }
			[XmlAttribute(AttributeName = "dampingMethod")]
			public string DampingMethod { get; set; }
			[XmlAttribute(AttributeName = "gasPreloadMethod")]
			public string GasPreloadMethod { get; set; }
			[XmlAttribute(AttributeName = "gasPreloadConstant")]
			public string GasPreloadConstant { get; set; }
		}

		[XmlRoot(ElementName = "BumpStopSpline", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class BumpStopSpline
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "id")]
			public string Id { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "interpolation_method")]
			public string Interpolation_method { get; set; }
			[XmlAttribute(AttributeName = "xLabel")]
			public string XLabel { get; set; }
			[XmlAttribute(AttributeName = "yLabel")]
			public string YLabel { get; set; }
			[XmlAttribute(AttributeName = "xUnit")]
			public string XUnit { get; set; }
			[XmlAttribute(AttributeName = "yUnit")]
			public string YUnit { get; set; }
			[XmlAttribute(AttributeName = "datablock")]
			public string Datablock { get; set; }
			[XmlText]
			public string Text { get; set; }
		}

		[XmlRoot(ElementName = "BumpStopProperties", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class BumpStopProperties
		{
			[XmlElement(ElementName = "BumpStopSpline", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<BumpStopSpline> BumpStopSpline { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "diameter")]
			public string Diameter { get; set; }
			[XmlAttribute(AttributeName = "height")]
			public string Height { get; set; }
			[XmlAttribute(AttributeName = "dampingMethod")]
			public string DampingMethod { get; set; }
			[XmlAttribute(AttributeName = "dampingRate")]
			public string DampingRate { get; set; }
			[XmlAttribute(AttributeName = "scaleFactor")]
			public string ScaleFactor { get; set; }
			[XmlAttribute(AttributeName = "linearRate")]
			public string LinearRate { get; set; }
			[XmlAttribute(AttributeName = "quadraticRate")]
			public string QuadraticRate { get; set; }
			[XmlAttribute(AttributeName = "cubicRate")]
			public string CubicRate { get; set; }
			[XmlAttribute(AttributeName = "method")]
			public string Method { get; set; }
			[XmlAttribute(AttributeName = "metalToMetalRate")]
			public string MetalToMetalRate { get; set; }
		}

		[XmlRoot(ElementName = "VIDriveSim", Namespace = "http://www.mscsoftware.com/:afc")]
		public class VIDriveSim
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
			[XmlAttribute(AttributeName = "systemFile")]
			public string SystemFile { get; set; }
			[XmlAttribute(AttributeName = "overlayCapable")]
			public string OverlayCapable { get; set; }
			[XmlAttribute(AttributeName = "doAnimation")]
			public string DoAnimation { get; set; }
			[XmlAttribute(AttributeName = "doPlot")]
			public string DoPlot { get; set; }
			[XmlAttribute(AttributeName = "doReport")]
			public string DoReport { get; set; }
			[XmlAttribute(AttributeName = "doCustomPostprocessing")]
			public string DoCustomPostprocessing { get; set; }
			[XmlAttribute(AttributeName = "integrationTimeStep")]
			public string IntegrationTimeStep { get; set; }
			[XmlAttribute(AttributeName = "outputTimeStep")]
			public string OutputTimeStep { get; set; }
			[XmlAttribute(AttributeName = "integrator")]
			public string Integrator { get; set; }
			[XmlAttribute(AttributeName = "useRoadFile")]
			public string UseRoadFile { get; set; }
			[XmlAttribute(AttributeName = "roadFile")]
			public string RoadFile { get; set; }
			[XmlAttribute(AttributeName = "fLroadFile")]
			public string FLroadFile { get; set; }
			[XmlAttribute(AttributeName = "fRroadFile")]
			public string FRroadFile { get; set; }
			[XmlAttribute(AttributeName = "rLroadFile")]
			public string RLroadFile { get; set; }
			[XmlAttribute(AttributeName = "rRroadFile")]
			public string RRroadFile { get; set; }
			[XmlAttribute(AttributeName = "individualRoad")]
			public string IndividualRoad { get; set; }
			[XmlAttribute(AttributeName = "useRoadGraphicsFile")]
			public string UseRoadGraphicsFile { get; set; }
			[XmlAttribute(AttributeName = "useEventLapSensorDRD")]
			public string UseEventLapSensorDRD { get; set; }
			[XmlAttribute(AttributeName = "lapSensor")]
			public string LapSensor { get; set; }
			[XmlAttribute(AttributeName = "simulationMode")]
			public string SimulationMode { get; set; }
			[XmlAttribute(AttributeName = "broadcastMode")]
			public string BroadcastMode { get; set; }
			[XmlAttribute(AttributeName = "showRoadWidgets")]
			public string ShowRoadWidgets { get; set; }
			[XmlAttribute(AttributeName = "showRoadGraphicsWidgets")]
			public string ShowRoadGraphicsWidgets { get; set; }
			[XmlAttribute(AttributeName = "showLapSensorWidgets")]
			public string ShowLapSensorWidgets { get; set; }
			[XmlAttribute(AttributeName = "enableIndividualRoad")]
			public string EnableIndividualRoad { get; set; }
			[XmlAttribute(AttributeName = "tireLimits")]
			public string TireLimits { get; set; }
			[XmlAttribute(AttributeName = "tLFZMin")]
			public string TLFZMin { get; set; }
			[XmlAttribute(AttributeName = "tLFZMax")]
			public string TLFZMax { get; set; }
			[XmlAttribute(AttributeName = "tLFZStep")]
			public string TLFZStep { get; set; }
			[XmlAttribute(AttributeName = "tLCamberMin")]
			public string TLCamberMin { get; set; }
			[XmlAttribute(AttributeName = "tLCamberMax")]
			public string TLCamberMax { get; set; }
			[XmlAttribute(AttributeName = "tLCamberStep")]
			public string TLCamberStep { get; set; }
			[XmlAttribute(AttributeName = "tLLongitudinalSlipMin")]
			public string TLLongitudinalSlipMin { get; set; }
			[XmlAttribute(AttributeName = "tLLongitudinalSlipMax")]
			public string TLLongitudinalSlipMax { get; set; }
			[XmlAttribute(AttributeName = "tLLongitudinalSlipStep")]
			public string TLLongitudinalSlipStep { get; set; }
			[XmlAttribute(AttributeName = "tLLateralSlipMin")]
			public string TLLateralSlipMin { get; set; }
			[XmlAttribute(AttributeName = "tLLateralSlipMax")]
			public string TLLateralSlipMax { get; set; }
			[XmlAttribute(AttributeName = "tLLateralSlipStep")]
			public string TLLateralSlipStep { get; set; }
			[XmlAttribute(AttributeName = "showTrailerWidgets")]
			public string ShowTrailerWidgets { get; set; }
			[XmlAttribute(AttributeName = "showSolverSettingsWidgets")]
			public string ShowSolverSettingsWidgets { get; set; }
			[XmlAttribute(AttributeName = "showTireLimitsWidgets")]
			public string ShowTireLimitsWidgets { get; set; }
			[XmlAttribute(AttributeName = "showVehicleVariantsWidgets")]
			public string ShowVehicleVariantsWidgets { get; set; }
			[XmlAttribute(AttributeName = "trailerActiveFlag")]
			public string TrailerActiveFlag { get; set; }
			[XmlAttribute(AttributeName = "plotConfigFile")]
			public string PlotConfigFile { get; set; }
			[XmlAttribute(AttributeName = "multipleLapsFlag")]
			public string MultipleLapsFlag { get; set; }
			[XmlAttribute(AttributeName = "multipleLapsMin")]
			public string MultipleLapsMin { get; set; }
			[XmlAttribute(AttributeName = "multipleLapsMax")]
			public string MultipleLapsMax { get; set; }
			[XmlAttribute(AttributeName = "multipleLapsVelocityTolerance")]
			public string MultipleLapsVelocityTolerance { get; set; }
			[XmlAttribute(AttributeName = "multipleLapsSplitResults")]
			public string MultipleLapsSplitResults { get; set; }
			[XmlAttribute(AttributeName = "driverParametersUpdate")]
			public string DriverParametersUpdate { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserLocationActive")]
			public string VehicleUserLocationActive { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserAutomaticZActive")]
			public string VehicleUserAutomaticZActive { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserLocationX")]
			public string VehicleUserLocationX { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserLocationY")]
			public string VehicleUserLocationY { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserLocationZ")]
			public string VehicleUserLocationZ { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserOrientationYaw")]
			public string VehicleUserOrientationYaw { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserOrientationPitch")]
			public string VehicleUserOrientationPitch { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserOrientationRoll")]
			public string VehicleUserOrientationRoll { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserStdTireRefLocationActive")]
			public string VehicleUserStdTireRefLocationActive { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserStdTireRefLocationX")]
			public string VehicleUserStdTireRefLocationX { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserStdTireRefLocationY")]
			public string VehicleUserStdTireRefLocationY { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserStdTireRefLocationZ")]
			public string VehicleUserStdTireRefLocationZ { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserStdTireRefOrientationPsi")]
			public string VehicleUserStdTireRefOrientationPsi { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserStdTireRefOrientationTheta")]
			public string VehicleUserStdTireRefOrientationTheta { get; set; }
			[XmlAttribute(AttributeName = "vehicleUserStdTireRefOrientationPhi")]
			public string VehicleUserStdTireRefOrientationPhi { get; set; }
			[XmlAttribute(AttributeName = "eventClass")]
			public string EventClass { get; set; }
			[XmlAttribute(AttributeName = "initialVelocity")]
			public string InitialVelocity { get; set; }
			[XmlAttribute(AttributeName = "initialGear")]
			public string InitialGear { get; set; }
			[XmlAttribute(AttributeName = "VIDriveSimEvent")]
			public string VIDriveSimEvent { get; set; }
			[XmlAttribute(AttributeName = "VIDriveSim")]
			public string _VIDriveSim { get; set; }
			[XmlAttribute(AttributeName = "VIDriveSimFilesPath")]
			public string VIDriveSimFilesPath { get; set; }
			[XmlAttribute(AttributeName = "userVdfFileFlag")]
			public string UserVdfFileFlag { get; set; }
			[XmlAttribute(AttributeName = "userVdfFile")]
			public string UserVdfFile { get; set; }
			[XmlAttribute(AttributeName = "SCANeR_mode")]
			public string SCANeR_mode { get; set; }
		}

		[XmlRoot(ElementName = "System", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class System
		{
			[XmlElement(ElementName = "ParameterTree", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<ParameterTree> ParameterTree { get; set; }
			[XmlElement(ElementName = "Subsystem", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<Subsystem> Subsystem { get; set; }
			[XmlElement(ElementName = "Context", Namespace = "http://www.mscsoftware.com/:vfc")]
			public Context Context { get; set; }
			[XmlElement(ElementName = "SpringProperties", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<SpringProperties> SpringProperties { get; set; }
			[XmlElement(ElementName = "DamperProperties", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<DamperProperties> DamperProperties { get; set; }
			[XmlElement(ElementName = "BumpStopProperties", Namespace = "http://www.mscsoftware.com/:vfc")]
			public List<BumpStopProperties> BumpStopProperties { get; set; }
			[XmlElement(ElementName = "VIDriveSim", Namespace = "http://www.mscsoftware.com/:afc")]
			public VIDriveSim VIDriveSim { get; set; }
			[XmlAttribute(AttributeName = "active")]
			public string Active { get; set; }
			[XmlAttribute(AttributeName = "userDefined")]
			public string UserDefined { get; set; }
		}

		[XmlRoot(ElementName = "afc", Namespace = "http://www.mscsoftware.com/:vfc")]
		public class Afc
		{
			[XmlElement(ElementName = "System", Namespace = "http://www.mscsoftware.com/:vfc")]
			public System System { get; set; }
			[XmlAttribute(AttributeName = "xmlns")]
			public string Xmlns { get; set; }
			[XmlAttribute(AttributeName = "afc", Namespace = "http://www.w3.org/2000/xmlns/")]
			public string _afc { get; set; }
		}

	}




